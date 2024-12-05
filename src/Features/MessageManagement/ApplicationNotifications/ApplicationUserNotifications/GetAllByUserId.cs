using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Mediator;

namespace Forpost.Features.MessageManagement.ApplicationNotifications.ApplicationUserNotifications;

internal sealed class GetAllNotificationsByUserIdQueryHandler : IQueryHandler<GetAllNotificationsByUserIdQuery,
    IReadOnlyCollection<ApplicationUserNotification>>
{
    private readonly IApplicationUserNotificationDomainRepository _applicationUserNotificationDomainRepository;

    public GetAllNotificationsByUserIdQueryHandler(
        IApplicationUserNotificationDomainRepository applicationUserNotificationDomainRepository)
    {
        _applicationUserNotificationDomainRepository = applicationUserNotificationDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<ApplicationUserNotification>> Handle(
        GetAllNotificationsByUserIdQuery query,
        CancellationToken cancellationToken)
    {
        var applicationUserNotifications =
            await _applicationUserNotificationDomainRepository.GetAllNotificationsByUserId(query.UserId,
                cancellationToken);
        return applicationUserNotifications;
    }
}

public record GetAllNotificationsByUserIdQuery(Guid UserId) : IQuery<IReadOnlyCollection<ApplicationUserNotification>>;