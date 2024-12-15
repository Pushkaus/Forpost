using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.TelegramData;

public sealed class TelegramAuthUser : DomainEntity
{
    public Guid EmployeeId { get; private set; }
    public long TelegramUserId { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool IsAuthorized { get; private set; }
    public string TelegramName { get; private set; }

    public static TelegramAuthUser Create(Guid employeeId, long telegramUserId, bool isAdmin, bool isAuthorized,
        string telegramName)
        => new(employeeId, telegramUserId, isAdmin, isAuthorized, telegramName);

    public void SetAuthorize(bool isAuthorized)
    {
        IsAuthorized = isAuthorized;
    }
    private TelegramAuthUser(Guid employeeId, long telegramUserId, bool isAdmin, bool isAuthorized, string telegramName)
    {
        EmployeeId = employeeId;
        TelegramUserId = telegramUserId;
        IsAdmin = isAdmin;
        IsAuthorized = isAuthorized;
        TelegramName = telegramName;
    }
}