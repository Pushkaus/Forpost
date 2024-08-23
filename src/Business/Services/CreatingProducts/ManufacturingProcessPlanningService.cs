using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.CreatingProducts.PlanningManufacturingProcessModel;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services.CreatingProducts;

internal sealed class ManufacturingProcessPlanningService: BaseBusinessService, IManufacturingProcessPlanningService
{
    public ManufacturingProcessPlanningService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BaseBusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider
        )
        : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task Planning(PlanningManufacturingProcessModel model, CancellationToken cancellationToken)
    {
        var manufacturingProcess = Mapper.Map<ManufacturingProcess>(model);
        
        manufacturingProcess.CurrentQuantity = 0;
        
        var manufacturingProcessId = DbUnitOfWork.ManufacturingProcessRepository.Add(manufacturingProcess);
        foreach (var issue in model.Issues)
        {
            var issueEntity = Mapper.Map<Issue>(issue);
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