using AutoMapper;
using Forpost.Domain.TelegramData;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.TelegramData;

internal sealed class TelegramAuthUserDomainRepository : DomainRepository<TelegramAuthUser>,
    ITelegramUserAuthDomainRepository
{
    public TelegramAuthUserDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<TelegramAuthUser?> GetUserByTelegramIdAsync(long telegramUserId, CancellationToken cancellationToken) 
        => await DbSet.FirstOrDefaultAsync(entity => entity.TelegramUserId == telegramUserId, cancellationToken);
}