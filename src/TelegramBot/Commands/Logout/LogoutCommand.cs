using Forpost.Domain.TelegramData;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Forpost.TelegramBot.Commands.Logout;

internal sealed class LogoutCommand : BaseTelegramCommandHandler
{
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;

    public LogoutCommand(
        ITelegramBotClient botClient,
        ITelegramUserAuthDomainRepository userAuthDomainRepository) : base(botClient)
    {
        _userAuthDomainRepository = userAuthDomainRepository;
    }

    public override string Command => "/logout";

    public override async Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        var chatId = update.Message!.Chat.Id;
        
        await _userAuthDomainRepository.LogoutAsync(chatId, cancellationToken);
        
        await BotClient.SendTextMessageAsync(chatId, "Вы вышли из аккаунта. Для повторной авторизации введите /start",
            cancellationToken: cancellationToken);
    }
}