using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Forpost.Features.MessageManagement.ApplicationNotifications.ApplicationUserNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.MessageManagement.ApplicationNotifications;

[Route("api/v1/application-user-notifications")]
public sealed class ApplicationUserNotificationController: ApiController
{
    /// <summary>
    /// Получить все подписки пользователя на уведомления.
    /// </summary>
    [HttpGet("{userId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ApplicationUserNotification>), StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<IActionResult> GetApplicationNotificationsByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken)
    {
        var applicationUserNotifications =
            await Sender.Send(new GetAllNotificationsByUserIdQuery(userId), cancellationToken);
        return Ok(applicationUserNotifications);
    }

    /// <summary>
    /// Подписать пользователя на уведомление.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)] 
    [ProducesResponseType(StatusCodes.Status400BadRequest)] 
    public async Task<IActionResult> SubscribeUserToNotification([FromBody] SubscribeUserToNotificationRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await Sender.Send(new AddUserNotificationCommand(request.UserId, request.NotificationId),
            cancellationToken); 
        return CreatedAtRoute(null , result);
    }

    /// <summary>
    /// Отписать пользователя от уведомления. 
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)] 
    public async Task<IActionResult> UnsubscribeUserFromNotification(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteUserNotificationByIdCommand(id), cancellationToken);
        return NoContent();
    }
}