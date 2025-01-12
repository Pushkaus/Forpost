using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Crm.PriceLists;

public sealed class PriceList: DomainAuditableEntity
{
    public Guid OperationId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }

}