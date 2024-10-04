using AutoMapper;
using Forpost.Application.Contracts.Issues;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Features.ProductCreating.Issues;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class ScheduledManufacturingProcessCommandHandler: ICommandHandler<ScheduledManufacturingProcessCommand, Guid>
{
    private readonly IManufacturingProcessDomainRepository _manufacturingProcessDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ScheduledManufacturingProcessCommandHandler(IManufacturingProcessDomainRepository manufacturingProcessDomainRepository, IIssueDomainRepository issueDomainRepository, IMapper mapper, ISender sender)
    {
        _manufacturingProcessDomainRepository = manufacturingProcessDomainRepository;
        _issueDomainRepository = issueDomainRepository;
        _mapper = mapper;
        _sender = sender;
    }

    public async ValueTask<Guid> Handle(ScheduledManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        var manufacturingProcess = ManufacturingProcess.Schedule(
            command.TechnologicalCardId,
            command.BatchNumber,
            command.TargetQuantity,
            command.StartTime);
        
        var manufacturingProcessId = _manufacturingProcessDomainRepository.Add(manufacturingProcess);
        foreach (var scheduledIssue in command.Issues)
        {
            ///TODO; Флаг, указывающий на состав продукта должен быть <= 1
            var issue = _mapper.Map<Issue>(scheduledIssue);
            issue.ManufacturingProcessId = manufacturingProcessId;
            
            issue.IssueNumber = await _issueDomainRepository.GetIssueNumber(command.TechnologicalCardId,
                issue.StepId, cancellationToken);
            
            _issueDomainRepository.Add(Issue.Schedule(issue));
        }
        return await ValueTask.FromResult(manufacturingProcessId);
    }
}

public record ScheduledManufacturingProcessCommand(): ICommand<Guid>
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