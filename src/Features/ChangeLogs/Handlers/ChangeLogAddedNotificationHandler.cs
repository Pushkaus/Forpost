using System.Security.Claims;
using Forpost.Common.Utils;
using Forpost.Domain.ChangeLogs;
using Forpost.Domain.ChangeLogs.Contracts;
using Forpost.Domain.ChangeLogs.Events;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;
using Microsoft.AspNetCore.Http;

namespace Forpost.Features.ChangeLogs.Handlers;

public sealed class ChangeLogAddedNotificationHandler : INotificationHandler<ChangeLogAdded>
{
    private readonly IChangeLogDomainRepository _domainRepository;
    private readonly IIdentityProvider _identityProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public ChangeLogAddedNotificationHandler(IChangeLogDomainRepository domainRepository,
        IIdentityProvider identityProvider, IHttpContextAccessor httpContextAccessor)
    {
        _domainRepository = domainRepository;
        _identityProvider = identityProvider;
        _httpContextAccessor = httpContextAccessor;
    }

    public ValueTask Handle(ChangeLogAdded notification, CancellationToken cancellationToken)
    {
        var changeLog = ChangeLog.Create(notification.Id, notification.PropertyName,
            notification.OldValue, notification.NewValue);

        _domainRepository.Add(changeLog);
        return ValueTask.CompletedTask;
    }
}