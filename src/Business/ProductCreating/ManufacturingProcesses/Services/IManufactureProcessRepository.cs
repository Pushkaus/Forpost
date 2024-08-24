namespace Forpost.Business.ProductCreating.ManufacturingProcesses.Services;

public interface IManufactureProcessRepository
{
    public Task<ManufacturingProcess> GetPlanningManufacturingProcessByIdAsync(Guid id, CancellationToken cancellationToken);
    
    public void Update(ManufacturingProcess manufacturingProcess);
}