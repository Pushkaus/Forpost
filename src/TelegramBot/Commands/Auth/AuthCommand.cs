using System.Collections.Concurrent;
using Forpost.Application.Contracts;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.TelegramData;
using Forpost.TelegramBot.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Forpost.TelegramBot.Commands.Auth;

internal sealed class AuthCommand : BaseTelegramCommandHandler
{
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IDbUnitOfWork _dbUnitOfWork;
    private readonly IPasswordHasher<Employee> _passwordHasher;

    public AuthCommand(
        ITelegramBotClient botClient,
        ITelegramUserAuthDomainRepository userAuthDomainRepository,
        IEmployeeDomainRepository employeeDomainRepository,
        IPasswordHasher<Employee> passwordHasher,
        IDbUnitOfWork dbUnitOfWork) : base(botClient)
    {
        _userAuthDomainRepository = userAuthDomainRepository;
        _employeeDomainRepository = employeeDomainRepository;
        _passwordHasher = passwordHasher;
        _dbUnitOfWork = dbUnitOfWork;
    }

    public override string Command => "/auth";

    public override async Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message.Chat.Id;
        var message = update.Message;

        var messageText = message.Text;

        if (messageText.StartsWith("/auth"))
        {
            await BotClient.SendTextMessageAsync(chatId,
                "Введите ваши данные в формате: Имя Фамилия Пароль",
                replyMarkup: new ForceReplyMarkup { Selective = true },
                cancellationToken: cancellationToken);
            return;
        }

        var parts = messageText.Split([' ', ',']);

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