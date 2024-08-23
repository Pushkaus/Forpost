namespace Forpost.Business.Abstract.Services.CreatingProducts;
/// <summary>
/// Отслеживание состояний производственного процесса
/// </summary>
public interface IManufacturingProcessMonitoringService: IBusinessService
{
    /// <summary>
    /// Получить статус задач
    /// </summary>
    /// <returns></returns>
    public Task GetStatusIssues();

    /// <summary>
    /// Получение продуктов, ожидающих упаковки
    /// </summary>
    /// <returns></returns>
    public Task GetProductsAwaitingPackaging();
}