using AutoMapper;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses.Events;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

public sealed class BatchProductionInitializedNotificationHandler : 
    INotificationHandler<ManufacturingProcessLaunched>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly IMapper _mapper;
    private readonly IDbUnitOfWork _dbUnitOfWork;

    public BatchProductionInitializedNotificationHandler(
        IProductDevelopmentDomainRepository productDevelopmentDomainRepository,
        IProductDevelopmentReadRepository productDevelopmentReadRepository,
        IMapper mapper,
        IIssueDomainRepository issueDomainRepository, IDbUnitOfWork dbUnitOfWork)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
        _mapper = mapper;
        _issueDomainRepository = issueDomainRepository;
        _dbUnitOfWork = dbUnitOfWork;
    }
    
    public async ValueTask Handle(ManufacturingProcessLaunched notification, CancellationToken cancellationToken)
    {
        var productDevelopmentSummary = await _productDevelopmentReadRepository
            .GetSummaryByManufacturingProcessIdAsync(notification.ManufacturingProcessId, cancellationToken);

        var issue = await _issueDomainRepository.GetFirstIssue(notification.ManufacturingProcessId, cancellationToken);
        for (int currentSequencNumber = 1;
             currentSequencNumber <= productDevelopmentSummary.TargetQuantity;
             currentSequencNumber++)
        {
            var productDevelopment = _mapper.Map<ProductDevelopment>(productDevelopmentSummary);
            productDevelopment.GenerateInitialSerialNumber(productDevelopmentSummary.BatchNumber, currentSequencNumber);
            productDevelopment.IssueId = issue.Id;
            productDevelopment.Id = Guid.NewGuid();
            _productDevelopmentDomainRepository.Add(productDevelopment);
        }
    }
}