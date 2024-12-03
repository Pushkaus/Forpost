using Forpost.TelegramBot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Commands;

internal abstract class BaseCommandHandler : ITelegramBotCommandHandler
{
    protected readonly ITelegramBotClient BotClient;

    protected BaseCommandHandler(
        ITelegramBotClient botClient)
    {
        BotClient = botClient;
    }
    
    public abstract string Command { get; }
    public abstract Task HandleAsync(Update update, CancellationToken cancellationToken);
}