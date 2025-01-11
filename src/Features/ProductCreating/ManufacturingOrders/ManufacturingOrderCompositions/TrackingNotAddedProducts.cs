using Forpost.Application.Contracts.CRM.InvoiceManagement.InvoiceProducts;
using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingOrders.Contracts;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

internal sealed class GetTrackingNotAddedProductsQueryHandler : IQueryHandler<GetTrackingNotAddedProductsQuery,
    IReadOnlyCollection<NotAddedProductsModel>>
{
    private readonly IInvoiceProductReadRepository _invoiceProductReadRepository;
    private readonly IManufacturingOrderCompositionReadRepository _manufacturingOrderCompositionReadRepository;
    private readonly IManufacturingOrderDomainRepository _manufacturingOrderDomainRepository;

    public GetTrackingNotAddedProductsQueryHandler(
        IInvoiceProductReadRepository invoiceProductReadRepository,
        IManufacturingOrderCompositionReadRepository manufacturingOrderCompositionReadRepository,
        IManufacturingOrderDomainRepository manufacturingOrderDomainRepository)
    {
        _invoiceProductReadRepository = invoiceProductReadRepository;
        _manufacturingOrderCompositionReadRepository = manufacturingOrderCompositionReadRepository;
        _manufacturingOrderDomainRepository = manufacturingOrderDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<NotAddedProductsModel>> Handle(GetTrackingNotAddedProductsQuery query,
        CancellationToken cancellationToken)
    {
        var order = await _manufacturingOrderDomainRepository.GetByIdAsync(query.ManufacturingOrderId, cancellationToken);
        order.EnsureFoundBy(x => x.Id, query.ManufacturingOrderId);

        var invoiceProducts = await _invoiceProductReadRepository
            .GetProductsByInvoiceIdAsync(order.InvoiceId, cancellationToken);

        var compositionOrder = await _manufacturingOrderCompositionReadRepository
            .GetCompositionByOrderIdAsync(query.ManufacturingOrderId, cancellationToken);

        var notAddedProducts = new List<NotAddedProductsModel>();

        foreach (var invoiceProduct in invoiceProducts)
        {
            var orderProduct = compositionOrder.FirstOrDefault(entity => entity.ProductId == invoiceProduct.ProductId);
            var quantityNotAdded = invoiceProduct.Quantity - (orderProduct?.Quantity ?? 0);

            if (quantityNotAdded > 0)
            {
                notAddedProducts.Add(new NotAddedProductsModel
                {
                    ManufacturingOrderId = query.ManufacturingOrderId,
                    ProductId = invoiceProduct.ProductId,
                    ProductName = invoiceProduct.Name, 
                    Quantity = quantityNotAdded
                });
            }
        }
        return notAddedProducts;
    }
}

public record GetTrackingNotAddedProductsQuery(Guid ManufacturingOrderId)
    : IQuery<IReadOnlyCollection<NotAddedProductsModel>>;

public class NotAddedProductsModel()
{
    public Guid ManufacturingOrderId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}