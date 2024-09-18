using AutoMapper;
using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ManufacturingProcesses.Events;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Forpost.Features.ProductCreating.ProductsDevelopments;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses.Handlers;

internal sealed class ManufacturingProcessLaunchedHandler: INotificationHandler<ManufacturingProcessLaunched>
{
   private readonly IManufacturingProcessDomainRepository _manufacturingProcessDomainRepository;
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly IMapper _mapper;
    
    public ManufacturingProcessLaunchedHandler(
        IManufacturingProcessDomainRepository manufacturingProcessDomainRepository,
        IProductDevelopmentDomainRepository productDevelopmentDomainRepository,
        IProductDevelopmentReadRepository productDevelopmentReadRepository,
        IMapper mapper,
        IIssueDomainRepository issueDomainRepository)
    {
        _manufacturingProcessDomainRepository = manufacturingProcessDomainRepository;
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
        _mapper = mapper;
        _issueDomainRepository = issueDomainRepository;
    }
    public async ValueTask Handle(ManufacturingProcessLaunched notification, CancellationToken cancellationToken)
    {
        var productDevelopmentSummary = await _productDevelopmentReadRepository
            .GetSummaryByManufacturingProcessIdAsync(notification.ManufacturingProcessId, cancellationToken);

        var productDevelopment = _mapper.Map<ProductDevelopment>(productDevelopmentSummary);
        var issue = await _issueDomainRepository.GetFirstIssue(notification.ManufacturingProcessId, cancellationToken);


        for (int currentSequencNumber = 1;
             currentSequencNumber <= productDevelopmentSummary.TargetQuantity;
             currentSequencNumber++)
        {
            productDevelopment.GenerateInitialSerialNumber(productDevelopmentSummary.BatchNumber, currentSequencNumber);
            productDevelopment.IssueId = issue.Id;
            productDevelopment.Id = Guid.NewGuid();
            _productDevelopmentDomainRepository.Add(productDevelopment);
        }
    }
}