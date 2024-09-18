using AutoMapper;
using Forpost.Common;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Domain.ProductCreating.CompositionProduct;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class CompleteIssueCommandHandler : ICommandHandler<CompleteIssueCommand>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;
    private readonly IIssueDomainRepository _issueDomainRepository;
    private readonly ICompletedProductDomainRepository _completedProductDomainRepository;
    private readonly ICompositionProductRepository _compositionProductRepository;
    private readonly IMapper _mapper;

    public CompleteIssueCommandHandler(
        IIssueDomainRepository issueDomainRepository,
        IProductDevelopmentDomainRepository productDevelopmentDomainRepository,
        IMapper mapper,
        ICompletedProductDomainRepository completedProductDomainRepository,
        ICompositionProductRepository compositionProductRepository)
    {
        _issueDomainRepository = issueDomainRepository;
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
        _mapper = mapper;
        _completedProductDomainRepository = completedProductDomainRepository;
        _compositionProductRepository = compositionProductRepository;
    }

    public async ValueTask<Unit> Handle(CompleteIssueCommand command, CancellationToken cancellationToken)
    {
        var productDevelopment =
            await _productDevelopmentDomainRepository.GetByIdAsync(command.ProductDevelopmentId, cancellationToken);

        productDevelopment.EnsureFoundBy(entity => entity.Id, command.ProductDevelopmentId);

        var currentIssue = await _issueDomainRepository.GetByIdAsync(command.IssueId, cancellationToken);
        var nextIssue = await _issueDomainRepository.GetNextIssue(command.IssueId, cancellationToken);
        var compositionProduct =
            await _compositionProductRepository.GetCompositionProductsAsync(productDevelopment.Id, cancellationToken);

        if (currentIssue.ProductCompositionSettingFlag && compositionProduct is null)
        {
            throw new InvalidOperationException("Состав продукта не указан, невозможно завершить задачу");
        }

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
            var completedProduct = CompletedProduct.Create(productDevelopment.ManufacturingProcessId,
                productDevelopment.Id, productDevelopment.ProductId);

            _completedProductDomainRepository.Add(completedProduct);
        }

        return Unit.Value;
    }
}

public record CompleteIssueCommand(Guid ProductDevelopmentId, Guid IssueId) : ICommand;