using AutoMapper;
using Forpost.Domain.Catalogs.TechCardItems;
using MediatR;

namespace Forpost.Features.Catalogs.TechCardItems;

internal sealed class AddTechCardItemCommandHandler : IRequestHandler<AddTechCardItemCommand, Guid>
{
    private readonly ITechCardItemDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddTechCardItemCommandHandler(ITechCardItemDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(AddTechCardItemCommand command, CancellationToken cancellationToken)
    {
        var techCardItem = _mapper.Map<TechCardItem>(command);
        return Task.FromResult(_domainRepository.Add(techCardItem));
    }
}

public record AddTechCardItemCommand(Guid TechCardId, Guid ProductId, int Quantity) : IRequest<Guid>;