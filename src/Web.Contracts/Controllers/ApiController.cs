using AutoMapper;
using Forpost.Common.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Web.Contracts.Controllers;

/// <summary>
/// Базовый контроллер для API
/// </summary>
[ApiController]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;
    private IMapper? _mapper;
    private IIdentityProvider? _identityProvider;

    /// <summary>
    /// MediatR для работы с обработчика команд и запросов
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    /// <summary>
    /// Automapper для маппинга Request в Command или Query. Или с Model на Response
    /// </summary>
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

    /// <summary>
    /// Поставщик авторизованого пользователя
    /// </summary>
    protected IIdentityProvider IdentityProvider =>
        _identityProvider ??= HttpContext.RequestServices.GetRequiredService<IIdentityProvider>();
}