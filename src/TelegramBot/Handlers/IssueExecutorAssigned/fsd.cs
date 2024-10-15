using System.Text;
using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.Issue.Events;
using Mediator;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Handlers.IssueExecutorAssigned;

public sealed class Fasd: ITelegramBotSender
{
    private readonly ITelegramBotClient _botClient;
    public Fasd(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Handle(Update update, CancellationToken cancellationToken)
    {
        if (update.Message.Text == "Privet")
        {
            await _botClient.SendTextMessageAsync(1013271587, "ты че куку?", cancellationToken: cancellationToken);
        }
        else
        {
            await _botClient.SendTextMessageAsync(1013271587, "ты че к2ку?", cancellationToken: cancellationToken);
        }
    }
}