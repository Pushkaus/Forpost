using AutoMapper;
using Forpost.Domain.MessageManager;
using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.MessageManager;

internal sealed class NotificationForUsersRepository : DomainRepository<NotificationForUsers>,
    INotificationForUsersDomainRepository
{
    public NotificationForUsersRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}