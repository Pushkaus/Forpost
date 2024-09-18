using AutoMapper;
using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class BatchProductionInitializedCommandHandler: ICommandHandler<BatchProductionInitializedCommand>
{
    private readonly IManufacturingProcessDomainRepository _manufacturingProcessDomainRepository;
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly IMapper _mapper;
    
    public BatchProductionInitializedCommandHandler(
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

    public async ValueTask<Unit> Handle(BatchProductionInitializedCommand command, CancellationToken cancellationToken)
    {
        var productDevelopmentSummary = await _productDevelopmentReadRepository
            .GetSummaryByManufacturingProcessIdAsync(command.ManufacturingProcessId, cancellationToken);

        var productDevelopment = _mapper.Map<ProductDevelopment>(productDevelopmentSummary);
        var issue = await _issueDomainRepository.GetFirstIssue(command.ManufacturingProcessId, cancellationToken);


        for (int currentSequencNumber = 1;
             currentSequencNumber <= productDevelopmentSummary.TargetQuantity;
             currentSequencNumber++)
        {
           productDevelopment.GenerateInitialSerialNumber(productDevelopmentSummary.BatchNumber, currentSequencNumber);
           productDevelopment.IssueId = issue.Id;
           productDevelopment.Id = Guid.NewGuid();
           _productDevelopmentDomainRepository.Add(productDevelopment);
        }
        
        return Unit.Value;
    }
}
public record BatchProductionInitializedCommand(Guid ManufacturingProcessId): ICommand;