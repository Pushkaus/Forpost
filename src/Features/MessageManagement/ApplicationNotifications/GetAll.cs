using Forpost.Application.Contracts.MessageManagement.ApplicationNotifications;
using Forpost.Common.ApplicationNotifications;
using Mediator;

namespace Forpost.Features.MessageManagement.ApplicationNotifications;

internal sealed class GetAllApplicationNotificationsQueryHandler : IQueryHandler<GetAllApplicationNotificationsQuery,
    IReadOnlyCollection<ApplicationNotification>>
{
    private readonly IApplicationNotificationReadRepository _applicationNotificationReadRepository;

    public GetAllApplicationNotificationsQueryHandler(
        IApplicationNotificationReadRepository applicationNotificationReadRepository)
    {
        _applicationNotificationReadRepository = applicationNotificationReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<ApplicationNotification>> Handle(
        GetAllApplicationNotificationsQuery query,
        CancellationToken cancellationToken)
    {
        var applicationsNotifications =
            await _applicationNotificationReadRepository.GetApplicationNotificationsAsync(cancellationToken);
        return applicationsNotifications;
    }
}

public record GetAllApplicationNotificationsQuery() : IQuery<IReadOnlyCollection<ApplicationNotification>>;