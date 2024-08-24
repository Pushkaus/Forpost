using AutoMapper;
using Forpost.Business.ProductCreating.ManufacturingProcesses.Services.Abstract;
using Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;
using Forpost.EventBus;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.ProductCreating.ManufacturingProcesses.Services;

internal sealed class ManufacturingProcessPlanningService: BusinessService, IManufacturingProcessPlanningService
{
    public ManufacturingProcessPlanningService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider
        )
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task Planning(PlanningManufacturingProcessCommand model, CancellationToken cancellationToken)
    {
        var manufacturingProcess = Mapper.Map<ManufacturingProcessEntity>(model);
        
        manufacturingProcess.CurrentQuantity = 0;
        
        var manufacturingProcessId = DbUnitOfWork.ManufacturingProcessRepository.Add(manufacturingProcess);
        foreach (var issue in model.Issues)
        {
            var issueEntity = Mapper.Map<IssueEntity>(issue);
            issueEntity.ManufacturingProcessId = manufacturingProcessId;
            issueEntity.ExecutorId = new Guid("0950ff47-bedf-4356-a2a0-315f9ce737ed"); // Сюда зарегаю эмплоя "Не определен"
            issueEntity.CurrentQuantity = 0;
            issueEntity.IssueStatus = IssueStatus.Pending;
            var issueEntityId = DbUnitOfWork.IssueRepository.Add(issueEntity);
        }
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        // Определение номера партии
        // Определение целевого количества готового продукта
        // Назначение ответственных над задачами (не исполнители) 
    }

    public Task Complete()
    {
        // Выставление даты конца производственного процесса (после того как все задачи завершенны) 
        throw new NotImplementedException();
    }

    public Task GetExecutionTime()
    {
        throw new NotImplementedException();
    }

    public Task GetStatusIssues()
    {
        throw new NotImplementedException();
    }

    public Task GetProductsAwaitingPackaging()
    {
        throw new NotImplementedException();
    }
}