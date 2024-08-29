namespace Forpost.Application.ProductCreating.ManufacturingProcesses.Services.Abstract;

public interface ManufacturingProcessAnalysisService
{
    /// <summary>
    /// Получение ожидаемого времени выполнения процесса
    /// </summary>
    public Task GetExecutionTime();
}