using AutoMapper;
using Forpost.Domain.Catalogs.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class AddStepCommandHandler : ICommandHandler<AddStepCommand, Guid>
{
    private readonly IStepDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddStepCommandHandler(IStepDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddStepCommand command, CancellationToken cancellationToken)
    {
        var step = _mapper.Map<Step>(command);
        return ValueTask.FromResult(_domainRepository.Add(step));
    }
}

public record AddStepCommand : ICommand<Guid>
{
    /// <summary>
    ///     Ссылка на тех.карту
    /// </summary>
    public Guid TechCardId { get; set; }

    /// <summary>
    ///     Ссылка на операцию (пайка/мойка/сборка и тд)
    /// </summary>
    public Guid OperationId { get; set; }

    /// <summary>
    ///     Описание задачи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Длительность задачи
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    ///     Стоимость задачи
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    ///     Единица измерения
    /// </summary>
    public UnitOfMeasure UnitOfMeasure { get; set; }
}
