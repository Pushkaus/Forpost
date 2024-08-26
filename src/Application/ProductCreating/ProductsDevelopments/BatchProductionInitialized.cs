using AutoMapper;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class BatchProductionInitializedCommandHandler: IRequestHandler<BatchProductionInitializedCommand>
{
    private readonly IManufacturingProcessRepository _manufacturingProcessRepository;
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;
    private readonly IProductDevelopmentRepository _productDevelopmentRepository;
    private readonly IMapper _mapper;
    public BatchProductionInitializedCommandHandler(IManufacturingProcessRepository manufacturingProcessRepository, IProductDevelopmentRepository productDevelopmentRepository, IProductDevelopmentReadRepository productDevelopmentReadRepository, IMapper mapper)
    {
        _manufacturingProcessRepository = manufacturingProcessRepository;
        _productDevelopmentRepository = productDevelopmentRepository;
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
        _mapper = mapper;
    }

    public async Task Handle(BatchProductionInitializedCommand command, CancellationToken cancellationToken)
    {
        var manufacturingProcess = await _manufacturingProcessRepository
            .GetByIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        var productDevelopmentSummary = await _productDevelopmentReadRepository
            .GetSummaryByManufacturingProcessIdAsync(command.ManufacturingProcessId, cancellationToken);
        
        var productDevelopment = _mapper.Map<ProductDevelopment>(productDevelopmentSummary);

        for (int currentSequencNumber = 1;
             currentSequencNumber <= productDevelopmentSummary.TargetQuantity;
             currentSequencNumber++)
        {
           productDevelopment.GenerateInitialSerialNumber(productDevelopmentSummary.BatchNumber, currentSequencNumber);
           _productDevelopmentRepository.Add(productDevelopment);
        }
    }
}
public record BatchProductionInitializedCommand(Guid ManufacturingProcessId): IRequest;