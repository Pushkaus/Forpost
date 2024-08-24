using Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;

namespace Forpost.Business.ProductCreating.ManufacturingProcesses.Services.Abstract;

/// <summary>
/// Сервис планирования производственного процесса
/// </summary>
public interface IManufacturingProcessPlanningService: IBusinessService
{
    /// <summary>
    /// Запуск производственного процесса
    /// </summary>
    /// <returns></returns>
    public Task Planning(PlanningManufacturingProcessCommand model, CancellationToken cancellationToken);


    
}