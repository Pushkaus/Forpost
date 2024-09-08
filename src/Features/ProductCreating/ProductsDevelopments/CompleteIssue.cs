using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class CompleteIssueCommandHandler : ICommandHandler<CompleteIssueCommand>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly ICompletedProductDomainRepository _completedProductDomainRepository;
    private readonly IMapper _mapper;

    public CompleteIssueCommandHandler(
        IIssueDomainRepository issueDomainRepository,
        IProductDevelopmentDomainRepository productDevelopmentDomainRepository,
        IMapper mapper,
        ICompletedProductDomainRepository completedProductDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
        _mapper = mapper;
        _completedProductDomainRepository = completedProductDomainRepository;
    }

    public async ValueTask<Unit> Handle(CompleteIssueCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment = _mapper.Map<ProductDevelopment>(
            await _productDevelopmentDomainRepository.GetByIdAsync(command.ProductDevelopmentId, cancellationToken));

        var currentIssue = _mapper.Map<Issue>(await _issueDomainRepository.GetByIdAsync(command.IssueId, cancellationToken));
        var nextIssue = _mapper.Map<Issue>(await _issueDomainRepository.GetNextIssue(command.IssueId, cancellationToken));

        if (nextIssue != null)
        {
            productDevelopment.IssueId = nextIssue.Id;
            _productDevelopmentDomainRepository.Update(productDevelopment);
            currentIssue.Complete();
            _issueDomainRepository.Update(currentIssue);
        }
        else
        {
            ///TODO;
            var completedProduct = CompletedProduct
                .Create(productDevelopment.ManufacturingProcessId, productDevelopment.Id);
            
            _completedProductDomainRepository.Add(completedProduct);
        }

        return Unit.Value;
    }
}

public record CompleteIssueCommand(Guid ProductDevelopmentId, Guid IssueId) : ICommand;
