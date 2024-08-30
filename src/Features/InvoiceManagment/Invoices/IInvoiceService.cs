// using Forpost.Domain.SortOut;
// using Forpost.Store.Entities;
//
// namespace Forpost.Business.SortOut;
//
// public interface IInvoiceService : IBusinessService
// {
//     public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
//     public Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken);
//     public Task<Guid> ExposeAsync(InvoiceCreateCommand model, CancellationToken cancellationToken);
//     public Task CloseAsync(InvoiceUpdateCommand model, CancellationToken cancellationToken);
//     public Task UpdateAsync(InvoiceUpdateCommand model, CancellationToken cancellationToken);
//     public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
// }