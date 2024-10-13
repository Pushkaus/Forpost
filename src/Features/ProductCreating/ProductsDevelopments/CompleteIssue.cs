using AutoMapper;
using Forpost.Application.Contracts;
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

    private readonly IDbUnitOfWork _dbUnitOfWork;

    public CompleteIssueCommandHandler(
        IIssueDomainRepository issueDomainRepository,
        IProductDevelopmentDomainRepository productDevelopmentDomainRepository,
        IMapper mapper,
        ICompletedProductDomainRepository completedProductDomainRepository,
        ICompositionProductRepository compositionProductRepository,
        IDbUnitOfWork dbUnitOfWork)
    {
        _issueDomainRepository = issueDomainRepository;
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
        _mapper = mapper;
        _completedProductDomainRepository = completedProductDomainRepository;
        _compositionProductRepository = compositionProductRepository;
        _dbUnitOfWork = dbUnitOfWork;
    }

    public async ValueTask<Unit> Handle(CompleteIssueCommand command, CancellationToken cancellationToken)
    {
        Issue currentIssue = null;

        foreach (var productDevelopmentId in command.ProductDevelopmentIds)
        {
            var productDevelopment =
                await _productDevelopmentDomainRepository.GetByIdAsync(productDevelopmentId, cancellationToken);

            productDevelopment.EnsureFoundBy(entity => entity.Id, productDevelopmentId);
            if (currentIssue == null)
            {
                currentIssue = await _issueDomainRepository.GetByIdAsync(productDevelopment.IssueId, cancellationToken);
            }

            var nextIssue = await _issueDomainRepository.GetNextIssue(productDevelopment.IssueId, cancellationToken);
            var compositionProduct =
                await _compositionProductRepository.GetCompositionProductsAsync(productDevelopment.Id,
                    cancellationToken);

            if (currentIssue.ProductCompositionSettingFlag && compositionProduct is null)
            {
                throw new Exception("Состав продукта не указан, невозможно завершить задачу");
            }

            if (nextIssue != null)
            {
                productDevelopment.IssueId = nextIssue.Id;
                _productDevelopmentDomainRepository.Update(productDevelopment);
            }
            else
            {
                productDevelopment.Status = ProductStatus.Completed;
                _productDevelopmentDomainRepository.Update(productDevelopment);
                var completedProduct = CompletedProduct.Create(productDevelopment.ManufacturingProcessId,
                    productDevelopment.Id, productDevelopment.ProductId);

                _completedProductDomainRepository.Add(completedProduct);
            }
            currentIssue.Complete();
            _issueDomainRepository.Update(currentIssue);
        }

        return Unit.Value;
    }
}

public record CompleteIssueCommand(IReadOnlyCollection<Guid> ProductDevelopmentIds) : ICommand;