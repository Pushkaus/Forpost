using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardOperations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardOperations;

internal sealed class
    GetTechCardStepByIdQueryHandler : IQueryHandler<GetTechCardOperationByIdQuery, EntityPagedResult<TechCardOperationModel>>
{
    private readonly ITechCardOperationReadRepository _techCardOperationReadRepository;

    public GetTechCardStepByIdQueryHandler(ITechCardOperationReadRepository techCardOperationReadRepository)
    {
        _techCardOperationReadRepository = techCardOperationReadRepository;
    }

    public async ValueTask<EntityPagedResult<TechCardOperationModel>> Handle(GetTechCardOperationByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _techCardOperationReadRepository.GetTechCardOperationsAsync(request.TechCardId, request.Filter,
            cancellationToken);
    }
}

public sealed record GetTechCardOperationByIdQuery(Guid TechCardId, TechCardOperationFilter Filter)
    : IQuery<EntityPagedResult<TechCardOperationModel>>;