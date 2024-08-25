// using AutoMapper;
// using Forpost.Application.Auth;
// using Forpost.Domain.Auth;
// using Forpost.Domain.Auth.Commands;
// using Forpost.Web.Contracts.Models.Accounts;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.Auth;
//
// /// <summary>
// /// Авторизация
// /// </summary>
// [ApiController]
// [Route("api/v1/accounts")]
// public sealed class AccountController : ControllerBase
// {
//     private readonly IAccountService _accountService;
//     private readonly IMapper _mapper;
//     private IMediator _mediator;
//     
//     public AccountController(IAccountService accountService, IMapper mapper, IMediator mediator)
//     {
//         _accountService = accountService;
//         _mapper = mapper;
//         _mediator = mediator;
//     }
//
//     /// <summary>
//     /// Регистрация сотрудника (регистрирует только админ?)
//     /// </summary>
//     [HttpPost]
//     [Authorize]
//     [ProducesResponseType(StatusCodes.Status201Created)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<IActionResult> RegisterAsync([FromQuery] RegisterUserRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<RegisterUserCommand>(request);
//         await _accountService.RegisterAsync(model, cancellationToken);
//
//         await _mediator.Send(model);
//         return Ok();
//     }
//
//     /// <summary>
//     /// Логин сотрудника
//     /// </summary>
//     [HttpPost("login")]
//     [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status201Created)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<string> LoginAsync([FromQuery] LoginUserRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<LoginUserCommand>(request);
//
//         var token = await _accountService.LoginAsync(model, cancellationToken);
//         return token;
//     }
// }