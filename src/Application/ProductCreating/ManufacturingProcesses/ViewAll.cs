using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using MediatR;

namespace Forpost.Application.ProductCreating.ManufacturingProcesses;

internal sealed class ViewManufacturingProcessesQueryHandler: IRequestHandler<ViewManufacturingProcessesQuery,IReadOnlyCollection<ManufacturingProcess>>
{
    private readonly IManufacturingProcessRepository _manufacturingProcessRepository;

    public ViewManufacturingProcessesQueryHandler(IManufacturingProcessRepository manufacturingProcessRepository)
    {
        _manufacturingProcessRepository = manufacturingProcessRepository;
    }

    public async Task<IReadOnlyCollection<ManufacturingProcess>> 
        Handle(ViewManufacturingProcessesQuery request, CancellationToken cancellationToken)
    {
        return await _manufacturingProcessRepository.GetAllAsync(cancellationToken);
    }
}
public record ViewManufacturingProcessesQuery() : IRequest<IReadOnlyCollection<ManufacturingProcess>>;