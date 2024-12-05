using Forpost.Application.Contracts.MessageManagement;
using Forpost.Features.MessageManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.MessageManager;
[Route("api/v1/nofitications-for-users")]
[Authorize]
public sealed class NotificationForUsersController: ApiController
{
    /// <summary>
    /// Получить все уведомления для пользователей
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<NotificationForUsersModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int limit = 100)
    {
        var result = await Sender.Send(new GetAllQuery(skip, limit));
        return Ok(new
        {
            Notifications = result.Notifications,
            TotalCount = result.TotalCount,
        });
    }
    /// <summary>
    /// Добавить уведомление для пользователей
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Publish([FromBody] NotificationForUsersRequest request)
    {
        await Sender.Send(new PublishCommand(request.Message));
        return Ok();
    }
}