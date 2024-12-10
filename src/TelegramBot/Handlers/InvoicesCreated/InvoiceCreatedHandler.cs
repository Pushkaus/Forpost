using Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;
using Forpost.Domain.CRM.InvoiceManagement.Events;
using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Forpost.Domain.TelegramData;
using Mediator;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Forpost.TelegramBot.Handlers.InvoicesCreated;
/// <summary>
/// Отправка уведомлений о создании счета
/// </summary>
public sealed class InvoiceCreatedHandler : INotificationHandler<InvoiceCreated>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;
    private readonly ITelegramUserAuthDomainRepository _userAuthDomainRepository;
    private readonly IApplicationUserNotificationDomainRepository _applicationUserNotificationDomainRepository;
    private readonly ITelegramBotClient _botClient;

    public InvoiceCreatedHandler(
        IInvoiceReadRepository invoiceReadRepository,
        ITelegramUserAuthDomainRepository userAuthDomainRepository,
        IApplicationUserNotificationDomainRepository applicationUserNotificationDomainRepository,
        ITelegramBotClient botClient)
    {
        _invoiceReadRepository = invoiceReadRepository;
        _userAuthDomainRepository = userAuthDomainRepository;
        _applicationUserNotificationDomainRepository = applicationUserNotificationDomainRepository;
        _botClient = botClient;
    }

    public async ValueTask Handle(InvoiceCreated notification, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceReadRepository.GetByIdAsync(notification.InvoiceId, cancellationToken);

        var messageText = $"Был создан счет!\n" +
                          $"Номер счета: {invoice.Number}\n" +
                          $"Контрагент: {invoice.ContragentName}\n" +
                          $"Описание: {invoice.Description ?? "Нет описания"}\n" +
                          $"Актуальность счета: {invoice.PaymentDeadline?.ToString("dd.MM.yyyy") ?? "Не указан"}\n" +
                          $"Приоритет: {invoice.Priority.Name}\n" +
                          $"Статус оплаты: {invoice.PaymentStatus.Name}\n";

        var userNotifications = await _applicationUserNotificationDomainRepository
            .GetAlldByNotificationName(nameof(InvoiceCreated), cancellationToken);

        var tasks = userNotifications.Select(async userNotification =>
        {
            var telegramAuthUser = await _userAuthDomainRepository
                .GetByUserIdAsync(userNotification.UserId, cancellationToken);

            if (telegramAuthUser != null)
            {
                await _botClient.SendTextMessageAsync(
                    telegramAuthUser.TelegramUserId, messageText, cancellationToken: cancellationToken);
            }
        });
        await Task.WhenAll(tasks);
    }
}