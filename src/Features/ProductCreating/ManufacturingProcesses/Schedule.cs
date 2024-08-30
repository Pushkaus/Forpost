using AutoMapper;
using Forpost.Application.Contracts.Issues;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using MediatR;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class ScheduledManufacturingProcessCommandHandler: IRequestHandler<ScheduledManufacturingProcessCommand, Guid>
{
    private readonly IManufacturingProcessDomainRepository _manufacturingProcessDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly IMapper _mapper;

    public ScheduledManufacturingProcessCommandHandler(IManufacturingProcessDomainRepository manufacturingProcessDomainRepository, IIssueDomainRepository issueDomainRepository, IMapper mapper)
    {
        _manufacturingProcessDomainRepository = manufacturingProcessDomainRepository;
        _issueDomainRepository = issueDomainRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(ScheduledManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        //TODO; Вызывать BatchProductionInitializedCommand
        var manufacturingProcess = ManufacturingProcess.Schedule(
            command.TechnologicalCardId,
            command.BatchNumber,
            command.TargetQuantity,
            command.StartTime);
        
        var manufacturingProcessId = _manufacturingProcessDomainRepository.Add(manufacturingProcess);
        foreach (var scheduledIssue in command.Issues)
        {
            var issue = _mapper.Map<Issue>(scheduledIssue);
            issue.ManufacturingProcessId = manufacturingProcessId;
            
            _issueDomainRepository.Add(Issue.Schedule(issue));
        }
        return await Task.FromResult(manufacturingProcessId);
    }
}

public record ScheduledManufacturingProcessCommand(): IRequest<Guid>
{
    public Guid TechnologicalCardId { get; set; }
    /// <summary>
    ///     Номер партии
    /// </summary>
    public string BatchNumber { get; set; } = null!;
    /// <summary>
    ///     Целевое количество продукта в производственном процессе
    /// </summary>
    public int TargetQuantity { get; set; }
    /// <summary>
    ///     Дата начала выполнения производственного процесса
    /// </summary>
    public DateTimeOffset StartTime { get; set; }
    /// <summary>
    /// Список задач в производственном процессе
    /// </summary>
    public IReadOnlyCollection<ScheduledIssue> Issues { get; set; } = Array.Empty<ScheduledIssue>();
}