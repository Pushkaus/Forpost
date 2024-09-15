using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class GetAllManufacturingProcessesQueryHandler:
    IQueryHandler<GetAllManufacturingProcessesQuery, (IReadOnlyCollection<ManufacturingProcessWithDetailsModel>, int TotalCount)>
{
    private readonly IManufacturingProcessReadRepository _manufacturingProcessReadRepository;

    public GetAllManufacturingProcessesQueryHandler(IManufacturingProcessReadRepository manufacturingProcessReadRepository)
    {
        _manufacturingProcessReadRepository = manufacturingProcessReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel>, int TotalCount)> 
        Handle(GetAllManufacturingProcessesQuery query, CancellationToken cancellationToken) =>
        await _manufacturingProcessReadRepository.GetAllAsync(query.Skip, query.Limit, cancellationToken);
}
public record GetAllManufacturingProcessesQuery(int Skip, int Limit): 
    IQuery<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel>, int TotalCount)>;