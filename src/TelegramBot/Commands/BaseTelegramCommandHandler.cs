using Forpost.TelegramBot.Handlers;
using Mediator;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Commands;

public abstract class BaseTelegramCommandHandler : ITelegramBotCommandHandler
{
    protected readonly ITelegramBotClient BotClient;

    protected BaseTelegramCommandHandler(
        ITelegramBotClient botClient)
    {
        BotClient = botClient;
    }
    
    public abstract string Command { get; }
    public abstract Task HandleAsync(Update update, CancellationToken cancellationToken);
}