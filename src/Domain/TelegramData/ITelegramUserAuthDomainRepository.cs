using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.TelegramData;

public interface ITelegramUserAuthDomainRepository: IDomainRepository<TelegramAuthUser>
{
    public Task<TelegramAuthUser?> GetUserByTelegramIdAsync(long telegramUserId, CancellationToken cancellationToken);
}