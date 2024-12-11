using Forpost.Application.Contracts;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.TelegramData;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Concurrent;
using System.Net.Http;
using Telegram.Bot.Types.Enums;

namespace Forpost.TelegramBot.Commands.Start;

internal sealed class StartCommand : BaseTelegramCommandHandler
{
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IPasswordHasher<Employee> _passwordHasher;
    private readonly IDbUnitOfWork _dbUnitOfWork;

    private static readonly ConcurrentDictionary<long, bool> UsersAwaitingInput = new();

    public StartCommand(
        ITelegramBotClient botClient,
        ITelegramUserAuthDomainRepository userAuthDomainRepository,
        IEmployeeDomainRepository employeeDomainRepository,
        IPasswordHasher<Employee> passwordHasher, IDbUnitOfWork dbUnitOfWork)
        : base(botClient)
    {
        _userAuthDomainRepository = userAuthDomainRepository;
        _employeeDomainRepository = employeeDomainRepository;
        _passwordHasher = passwordHasher;
        _dbUnitOfWork = dbUnitOfWork;
    }

    public override string Command => "/start";

    public override async Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        if (update.Type != UpdateType.Message || update.Message?.Text == null)
        {
            return; 
        }

        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text.Trim();

        if (messageText.StartsWith(Command, StringComparison.OrdinalIgnoreCase))
        {
            var existingUser = await _userAuthDomainRepository.GetByTelegramIdAsync(chatId, cancellationToken);

            if (existingUser != null && existingUser.IsAuthorized)
            {
                await BotClient.SendTextMessageAsync(chatId,
                    "Вы уже авторизованы! Добро пожаловать.",
                    cancellationToken: cancellationToken);
                return;
            }

            // Устанавливаем пользователя в режим ожидания данных
            UsersAwaitingInput[chatId] = true;

            await BotClient.SendTextMessageAsync(chatId,
                "Пожалуйста, введите свои данные в формате: Имя Фамилия Пароль",
                cancellationToken: cancellationToken);
            return;
        }

        // Проверяем, ожидает ли пользователь ввода данных
        if (UsersAwaitingInput.TryGetValue(chatId, out bool isAwaitingInput) && isAwaitingInput)
        {
            var parts = messageText.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                await BotClient.SendTextMessageAsync(chatId,
                    "Некорректный формат. Пожалуйста, введите данные в формате: Имя Фамилия Пароль",
                    cancellationToken: cancellationToken);
                return;
            }

            var firstName = parts[0];
            var lastName = parts[1];
            var password = parts[2];

            try
            {
                var employee = await _employeeDomainRepository
                    .GetAuthorizedByUsernameAsync(firstName, lastName, cancellationToken);

                if (employee != null)
                {
                    var verificationResult = _passwordHasher
                        .VerifyHashedPassword(employee, employee.PasswordHash, password);

                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        await AuthorizeUserAsync(employee.Id, chatId, update.Message.Chat.Username, cancellationToken);
                        UsersAwaitingInput.TryRemove(chatId, out _); 
                    }
                    else
                    {
                        await SendMessageWithRetryAsync(chatId, "Неверный пароль. Попробуйте снова.", cancellationToken);
                    }
                }
                else
                {
                    await SendMessageWithRetryAsync(chatId, "Пользователь не найден. Попробуйте снова.", cancellationToken);
                }
            }
            catch (HttpRequestException ex)
            {
                await SendMessageWithRetryAsync(chatId, "Произошла ошибка сети. Пожалуйста, попробуйте позже.", cancellationToken);
            }
            catch (Exception ex)
            { 
                await SendMessageWithRetryAsync(chatId, "Произошла ошибка. Попробуйте снова.", cancellationToken);
            }
        }
    }

    private async Task<bool> AuthorizeUserAsync(Guid employeeId, long chatId, string? username, CancellationToken cancellationToken)
    {
        var newTelegramUser = TelegramAuthUser.Create(employeeId, chatId, isAdmin: false,
            isAuthorized: true, username ?? "Неизвестно");

        _userAuthDomainRepository.Add(newTelegramUser);

        await _dbUnitOfWork.SaveChangesAsync(cancellationToken);

        await SendMessageWithRetryAsync(chatId, "Вы успешно авторизовались!", cancellationToken);

        return true;
    }

    private async Task SendMessageWithRetryAsync(long chatId, string messageText, CancellationToken cancellationToken, int maxRetries = 3)
    {
        var retryCount = 0;
        while (retryCount < maxRetries)
        {
            try
            {
                await BotClient.SendTextMessageAsync(chatId, messageText, cancellationToken: cancellationToken);
                break; 
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
                retryCount++;
                if (retryCount >= maxRetries)
                {
                    Console.WriteLine("Достигнуто максимальное количество попыток отправки сообщения.");
                    throw;
                }
                await Task.Delay(2000, cancellationToken); 
            }
        }
    }
}
