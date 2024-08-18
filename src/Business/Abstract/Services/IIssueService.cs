namespace Forpost.Business.Abstract.Services;

public interface IIssueService
{
    /// <summary>
    ///     Назначение/смена исполнителей
    /// </summary>
    /// <returns></returns>
    public Task AssignExecutor();

    /// <summary>
    ///     Старт этапа/задачи
    /// </summary>
    /// <returns></returns>
    public Task StartIssue();

    /// <summary>
    ///     Конец этапа/задачи
    /// </summary>
    /// <returns></returns>
    public Task EndIssue();

    /// <summary>
    ///     Добавление деталей к продукту в процессе
    /// </summary>
    /// <returns></returns>
    public Task AddDetailsOnProduct();
}