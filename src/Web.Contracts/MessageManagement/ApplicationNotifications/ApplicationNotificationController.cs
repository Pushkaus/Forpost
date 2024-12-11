using Forpost.Common.ApplicationNotifications;
using Forpost.Features.MessageManagement.ApplicationNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.MessageManagement.ApplicationNotifications;

[Route("api/v1/application-notifications")]
public sealed class ApplicationNotificationController : ApiController
{
    /// <summary>
    /// Получить все типы уведомлений в приложении.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ApplicationNotification>), StatusCodes.Status200OK)] 
    public async Task<IActionResult> GetAllApplicationNotificationsAsync(CancellationToken cancellationToken)
    {
        var applicationNotifications = await Sender.Send(new GetAllApplicationNotificationsQuery(), cancellationToken);
        return Ok(applicationNotifications);
    }
}