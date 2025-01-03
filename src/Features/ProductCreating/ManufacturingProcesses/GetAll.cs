using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class GetAllManufacturingProcessesQueryHandler :
    IQueryHandler<GetAllManufacturingProcessesQuery, (IReadOnlyCollection<ManufacturingProcessWithDetailsModel>
        ManufacturingProcesses, int TotalCount)>
{
    private readonly IManufacturingProcessReadRepository _manufacturingProcessReadRepository;

    public GetAllManufacturingProcessesQueryHandler(
        IManufacturingProcessReadRepository manufacturingProcessReadRepository)
    {
        _manufacturingProcessReadRepository = manufacturingProcessReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel> ManufacturingProcesses, int
            TotalCount)>
        Handle(GetAllManufacturingProcessesQuery query, CancellationToken cancellationToken) =>
        await _manufacturingProcessReadRepository.GetAllAsync(query.FilterExpression, query.FilterValues, query.Skip,
            query.Limit, cancellationToken);
}

public record GetAllManufacturingProcessesQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) :
    IQuery<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel> ManufacturingProcesses, int TotalCount)>;