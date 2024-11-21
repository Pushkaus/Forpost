using AutoMapper;
using Forpost.Domain.MessagesManagement;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.MessageManagement;

internal sealed class NotificationForUsersRepository : DomainRepository<NotificationForUsers>,
    INotificationForUsersDomainRepository
{
    public NotificationForUsersRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }
}