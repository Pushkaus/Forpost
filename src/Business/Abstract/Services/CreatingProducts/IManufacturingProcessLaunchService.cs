namespace Forpost.Business.Abstract.Services.CreatingProducts;

public interface IManufacturingProcessLaunchService: IBusinessService
{
    /// <summary>
    /// Запуск производственного процесса
    /// </summary>
    /// <returns></returns>
    public Task Launch(Guid manufacturingProcessId, CancellationToken cancellationToken);
    /// <summary>
    /// Завершение производственного процесса
    /// </summary>
    /// <returns></returns>
    public Task Complete();
}