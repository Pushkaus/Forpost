using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.TelegramData;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Forpost.TelegramBot.Commands.Start;

public sealed class StartCommand : BaseTelegramCommandHandler
{
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IPasswordHasher<Employee> _passwordHasher;

    public StartCommand(
        ITelegramBotClient botClient,
        ITelegramUserAuthDomainRepository userAuthDomainRepository,
        IEmployeeDomainRepository employeeDomainRepository,
        IPasswordHasher<Employee> passwordHasher)
        : base(botClient)
    {
        _userAuthDomainRepository = userAuthDomainRepository;
        _employeeDomainRepository = employeeDomainRepository;
        _passwordHasher = passwordHasher;
    }

    public override string Command => "/start";

    public override async Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        var message = update.Message;
        var messageText = message.Text;

        var existingUser = await _userAuthDomainRepository.GetByTelegramIdAsync(chatId, cancellationToken);

        if (existingUser != null && existingUser.IsAuthorized)
        {
            await BotClient.SendTextMessageAsync(chatId,
                "Вы уже авторизованы! Добро пожаловать.",
                cancellationToken: cancellationToken);
            return;
        }
        
        var parts = messageText.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 3)
        {
            await BotClient.SendTextMessageAsync(chatId,
                "Пожалуйста, введите данные в правильном формате: Имя Фамилия Пароль",
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
                    var newTelegramUser = TelegramAuthUser.Create(employee.Id, chatId, isAdmin: false,
                        isAuthorized: true, message.Chat.Username);

                    _userAuthDomainRepository.Add(newTelegramUser);

                    await BotClient.SendTextMessageAsync(chatId, "Вы успешно авторизовались!",
                        cancellationToken: cancellationToken);
                }
                else
                {
                    await BotClient.SendTextMessageAsync(chatId, "Неверный пароль. Попробуйте снова.",
                        cancellationToken: cancellationToken);
                }
            }
            else
            {
                await BotClient.SendTextMessageAsync(chatId, "Пользователь не найден. Попробуйте снова.",
                    cancellationToken: cancellationToken);
            }
        }
        catch (Exception)
        {
            await BotClient.SendTextMessageAsync(chatId, "Произошла ошибка. Попробуйте снова.",
                cancellationToken: cancellationToken);
        }
    }
}
