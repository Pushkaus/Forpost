namespace Forpost.Business.Abstract.Services;

/// <summary>
///     Сервис, для работы с производственным процессом
/// </summary>
public interface IManufacturingProcessService
{
    /// <summary>
    ///     Запуск производственного процесса
    /// </summary>
    /// <returns></returns>
    public Task Launch();

    /// <summary>
    ///     Завершение производственного процесса
    /// </summary>
    /// <returns></returns>
    public Task Complete();

    /// <summary>
    ///     Получение ожидаемого времени выполнения процесса
    /// </summary>
    /// <returns></returns>
    public Task GetExecutionTime();

    /// <summary>
    ///     Получить статус задач
    /// </summary>
    /// <returns></returns>
    public Task GetStatusIssues();

    /// <summary>
    ///     Получение продуктов, ожидающих упаковки
    /// </summary>
    /// <returns></returns>
    public Task GetProductsAwaitingPackaging();
}