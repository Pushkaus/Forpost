using Forpost.Business.Models.CreatingProducts.PlanningManufacturingProcessModel;

namespace Forpost.Business.Abstract.Services.CreatingProducts;

/// <summary>
/// Сервис планирования производственного процесса
/// </summary>
public interface IManufacturingProcessPlanningService: IBusinessService
{
    /// <summary>
    /// Запуск производственного процесса
    /// </summary>
    /// <returns></returns>
    public Task Planning(PlanningManufacturingProcessModel model, CancellationToken cancellationToken);


    
}