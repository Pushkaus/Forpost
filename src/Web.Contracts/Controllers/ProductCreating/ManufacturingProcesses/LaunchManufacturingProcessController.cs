// using AutoMapper;
// using Forpost.Domain.ProductCreating.ManufacturingProcesses.Services.Abstract;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.ProductCreating.ManufacturingProcesses;
//
// [ApiController]
// [Route("api/v1/LaunchManufacturingProcesses")]
// public sealed class LaunchManufacturingProcessController : ControllerBase
// {
//     private readonly IManufacturingProcessLaunchService _manufacturingProcessLaunchService;
//     private readonly IMapper _mapper;
//
//     public LaunchManufacturingProcessController(
//         IMapper mapper,
//         IManufacturingProcessLaunchService manufacturingProcessLaunchService)
//     {
//         _mapper = mapper;
//         _manufacturingProcessLaunchService = manufacturingProcessLaunchService;
//     }
//
//     [HttpPut("{manufacturingProcessId}")]
//     public async Task<IActionResult> Launch(Guid manufacturingProcessId, CancellationToken cancellationToken)
//     {
//         await _manufacturingProcessLaunchService.Launch(manufacturingProcessId, cancellationToken);
//         return Ok();
//     }
// }