using AutoMapper;
using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class TechCardCreateCommandHandler : ICommandHandler<AddTechCardCommand, Guid>
{
    private readonly ITechCardDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public TechCardCreateCommandHandler(ITechCardDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(AddTechCardCommand command, CancellationToken cancellationToken)
    {
        var techCard = _mapper.Map<TechCard>(command);
        return ValueTask.FromResult(_domainRepository.Add(techCard));
    }
}

public record AddTechCardCommand : ICommand<Guid>
{
    /// <summary>
    ///     Номер тех.карты
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    ///     Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    ///     Создатель тех.карты
    /// </summary>
    public Guid CreatedById { get; set; }
}