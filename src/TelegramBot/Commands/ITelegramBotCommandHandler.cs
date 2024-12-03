using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Commands;
/// <summary>
/// Маркерный интерфейс, где бот является обработчиком сообщений
/// </summary>
public interface ITelegramBotCommandHandler
{
    public string Command { get; }
    Task HandleAsync(Update update, CancellationToken cancellationToken);
}