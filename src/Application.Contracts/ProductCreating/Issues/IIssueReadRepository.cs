using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.Issues;

public interface IIssueReadRepository: IApplicationReadRepository
{
    public Task<List<IssueFromManufacturingProcessModel>> GetAllFromManufacturingProcessId(Guid manufacturingProcessId,
        CancellationToken cancellationToken);
    /// <summary>
    /// Получение всех актуальных задач для исполнителя
    /// </summary>
    public Task<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)> 
        GetIssuesByExecutorId(Guid executorId, CancellationToken cancellationToken, int skip, int limit);
    /// <summary>
    /// Получение всех актуальных задач для ответственного
    /// </summary>
    public Task<(IReadOnlyCollection<IssueModel> Issues, int TotalCount)> 
        GetIssuesByResponsibleId(Guid responsibleId, CancellationToken cancellationToken, int skip, int limit);
}