using Forpost.Application.Contracts.MessageManagment;
using Forpost.Features.MessageManagment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.MessageManager;
[Route("api/v1/nofitications-for-users")]
public sealed class NotificationForUsersController: ApiController
{
    /// <summary>
    /// Получить все уведомления для пользователей
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
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
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Publish([FromBody] NotificationForUsersRequest request)
    {
        await Sender.Send(new PublishCommand(request.Message));
        return Ok();
    }
}