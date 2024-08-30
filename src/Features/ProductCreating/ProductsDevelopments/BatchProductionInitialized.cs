using AutoMapper;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class BatchProductionInitializedCommandHandler: IRequestHandler<BatchProductionInitializedCommand>
{
    private readonly IManufacturingProcessDomainRepository _manufacturingProcessDomainRepository;
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;
    private readonly IMapper _mapper;
    public BatchProductionInitializedCommandHandler(IManufacturingProcessDomainRepository manufacturingProcessDomainRepository, IProductDevelopmentDomainRepository productDevelopmentDomainRepository, IProductDevelopmentReadRepository productDevelopmentReadRepository, IMapper mapper)
    {
        _manufacturingProcessDomainRepository = manufacturingProcessDomainRepository;
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
        _mapper = mapper;
    }

    public async Task Handle(BatchProductionInitializedCommand command, CancellationToken cancellationToken)
    {
        var manufacturingProcess = await _manufacturingProcessDomainRepository
            .GetByIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        var productDevelopmentSummary = await _productDevelopmentReadRepository
            .GetSummaryByManufacturingProcessIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        var productDevelopment = _mapper.Map<ProductDevelopment>(productDevelopmentSummary);

        for (int currentSequencNumber = 1;
             currentSequencNumber <= productDevelopmentSummary.TargetQuantity;
             currentSequencNumber++)
        {
           productDevelopment.GenerateInitialSerialNumber(productDevelopmentSummary.BatchNumber, currentSequencNumber);
           _productDevelopmentDomainRepository.Add(productDevelopment);
        }
    }
}
public record BatchProductionInitializedCommand(Guid ManufacturingProcessId): IRequest;