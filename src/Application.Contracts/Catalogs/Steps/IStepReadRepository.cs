using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Steps;

public interface IStepReadRepository: IApplicationReadRepository
{
    public Task<StepWithSummary?> GetStepWithSummaryByIdAsync(Guid stepId, CancellationToken cancellationToken);
}