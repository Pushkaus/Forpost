using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Forpost.TelegramBot.Commands.Help;

internal sealed class Help : BaseCommandHandler
{
    public Help(ITelegramBotClient botClient)
        : base(botClient)
    {
    }

    public override string Command => "/help";

    public override async Task HandleAsync(Update update, CancellationToken cancellationToken)
    {
        var messageText = "Список доступных команд: ";
        await BotClient.SendTextMessageAsync(update.Message.Chat.Id, messageText, cancellationToken: cancellationToken);
    }
}