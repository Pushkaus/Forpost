using Forpost.Store.Entities;

namespace Forpost.Business.Sortout;

public interface IInvoiceService : IBusinessService
{
    public Task<InvoiceEntity?> GetByNumberAsync(string number, CancellationToken cancellationToken);
    public Task<IReadOnlyList<InvoiceEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Guid> ExposeAsync(InvoiceCreateCommand model, CancellationToken cancellationToken);
    public Task CloseAsync(InvoiceUpdateCommand model, CancellationToken cancellationToken);
    public Task UpdateAsync(InvoiceUpdateCommand model, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}