using Forpost.Domain.CRM.InvoiceManagement;

namespace Forpost.TelegramBot.Handlers.InvoicesCreated;

internal static class InvoiceEnumTranslations
{
    public static readonly Dictionary<string, string> PaymentStatusTranslations = new()
    {
        { nameof(PaymentStatus.NotPaid), "Не оплачено" },
        { nameof(PaymentStatus.AdvancePaid), "Аванс" },
        { nameof(PaymentStatus.PaidFull), "Оплачено полностью" }
    };

    public static readonly Dictionary<string, string> PriorityTranslations = new()
    {
        { nameof(Priority.Low), "Низкий" },
        { nameof(Priority.Normal), "Средний" },
        { nameof(Priority.High), "Высокий" }
    };
}