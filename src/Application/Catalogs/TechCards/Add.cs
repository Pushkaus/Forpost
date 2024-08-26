using AutoMapper;
using Forpost.Domain.Catalogs.TechCards;
using MediatR;

namespace Forpost.Application.Catalogs.TechCards;

internal sealed class TechCardCreateCommandHandler : IRequestHandler<AddTechCardCommand, Guid>
{
    private readonly ITechCardRepository _repository;
    private readonly IMapper _mapper;

    public TechCardCreateCommandHandler(ITechCardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddTechCardCommand command, CancellationToken cancellationToken)
    {
        var techCard = _mapper.Map<TechCard>(command);
        return Task.FromResult(_repository.Add(techCard));
    }
}

public record AddTechCardCommand : IRequest<Guid>
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