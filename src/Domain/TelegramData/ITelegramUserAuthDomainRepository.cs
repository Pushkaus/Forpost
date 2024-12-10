using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.TelegramData;

public interface ITelegramUserAuthDomainRepository: IDomainRepository<TelegramAuthUser>
{
    public Task<TelegramAuthUser?> GetByTelegramIdAsync(long telegramUserId, CancellationToken cancellationToken);
    public Task<TelegramAuthUser?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    public Task LogoutAsync(long telegramUserId, CancellationToken cancellationToken);
}