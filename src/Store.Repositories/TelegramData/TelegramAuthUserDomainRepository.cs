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

    public async Task<TelegramAuthUser?> GetByTelegramIdAsync(long telegramUserId, CancellationToken cancellationToken)
        => await DbSet.FirstOrDefaultAsync(entity => entity.TelegramUserId == telegramUserId, cancellationToken);

    public async Task<TelegramAuthUser?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        => await DbSet.FirstOrDefaultAsync(entity => entity.EmployeeId == userId, cancellationToken);

    public async Task LogoutAsync(long telegramUserId, CancellationToken cancellationToken)
    {
        var user = await DbSet.FirstOrDefaultAsync(entity => entity.TelegramUserId == telegramUserId, cancellationToken);
    
        if (user != null)
        {
            DbSet.Remove(user);
        
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

}