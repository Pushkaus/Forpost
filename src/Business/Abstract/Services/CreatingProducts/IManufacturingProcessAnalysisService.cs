namespace Forpost.Business.Abstract.Services.CreatingProducts;

public interface IManufacturingProcessAnalysisService
{
    /// <summary>
    /// Получение ожидаемого времени выполнения процесса
    /// </summary>
    /// <returns></returns>
    public Task GetExecutionTime();
}