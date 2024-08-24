namespace Forpost.Business.Sortout;
/// <summary>
/// Сервис по управлению задачами производственного процесса
/// </summary>
public interface IIssueManagementService
{
    /// <summary>
    /// Назначение исполнителя задачи
    /// </summary>
    /// <param name="userId">ID исполнителя</param>
    /// <param name="issueId">ID задачи</param>
    /// <returns></returns>
    public Task AssignExecutorAsync(Guid userId, Guid issueId);
    /// <summary>
    /// Завершение задачи
    /// </summary>
    /// <param name="issueId">ID задачи</param>
    /// <returns></returns>
    public Task CompleteAsync(Guid issueId);
    
}