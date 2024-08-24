using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceService : IBusinessService
{
    public Task<InvoiceEntity?> GetByNumberAsync(string number, CancellationToken cancellationToken);
    public Task<IReadOnlyList<InvoiceEntity>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Guid> ExposeAsync(InvoiceCreateModel model, CancellationToken cancellationToken);
    public Task CloseAsync(InvoiceUpdateModel model, CancellationToken cancellationToken);
    public Task UpdateAsync(InvoiceUpdateModel model, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}