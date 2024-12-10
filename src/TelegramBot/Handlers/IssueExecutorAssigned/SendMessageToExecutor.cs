using System.Text;
using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.Issue.Events;
using Mediator;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Handlers.IssueExecutorAssigned;

public sealed class SendMessageToExecutor : INotificationHandler<ExecutorAssigned>, ITelegramBotHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly IIssueReadRepository _issueReadRepository;

    public SendMessageToExecutor(ITelegramBotClient botClient, IIssueReadRepository issueReadRepository)
    {
        _botClient = botClient;
        _issueReadRepository = issueReadRepository;
    }

    public async ValueTask Handle(ExecutorAssigned notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"{notification.ExecutorId} executor assigned");
        var issue = await _issueReadRepository.GetById(notification.IssueId, cancellationToken);
        var messageText = $"Вы назначены исполнителем задачи:\n" +
                             $"Операция: {issue.OperationName}\n" +
                             $"Продукт: {issue.ProductName}\n" +
                             $"Целевое количество: {issue.TargetQuantity}\n" +
                             $"Ответственный: {issue.ResponsibleName}";
        
        await _botClient.SendTextMessageAsync(1013271587, messageText,
            cancellationToken: cancellationToken);
    }
}