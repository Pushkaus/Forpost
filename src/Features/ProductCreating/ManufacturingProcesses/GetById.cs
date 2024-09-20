using Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class GetManufacturingProcessByIdQueryHandler: IQueryHandler<GetManufacturingProcessByIdQuery, ManufacturingProcessWithDetailsModel?>
{
    private readonly IManufacturingProcessReadRepository _manufacturingProcessReadRepository;

    public GetManufacturingProcessByIdQueryHandler(IManufacturingProcessReadRepository manufacturingProcessReadRepository)
    {
        _manufacturingProcessReadRepository = manufacturingProcessReadRepository;
    }

    public async ValueTask<ManufacturingProcessWithDetailsModel?> Handle(GetManufacturingProcessByIdQuery query, CancellationToken cancellationToken) 
        => await _manufacturingProcessReadRepository.GetByIdAsync(query.Id, cancellationToken);
}
public record GetManufacturingProcessByIdQuery(Guid Id): IQuery<ManufacturingProcessWithDetailsModel>;