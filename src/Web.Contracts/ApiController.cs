using AutoMapper;
using Forpost.Common.Utils;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Web.Contracts;

/// <summary>
/// Базовый контроллер для API
/// </summary>
[ApiController]
public abstract class ApiController : ControllerBase
{
    private ISender? _sender;
    private IMapper? _mapper;
    private IIdentityProvider? _identityProvider;

    /// <summary>
    /// Отправитель команд и запросов для работы с обработчика команд и запросов
    /// </summary>
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    /// <summary>
    /// Automapper для маппинга Request в Command или Query. Или с Model на Response
    /// </summary>
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

    /// <summary>
    /// Поставщик авторизованного пользователя
    /// </summary>
    protected IIdentityProvider IdentityProvider =>
        _identityProvider ??= HttpContext.RequestServices.GetRequiredService<IIdentityProvider>();
}