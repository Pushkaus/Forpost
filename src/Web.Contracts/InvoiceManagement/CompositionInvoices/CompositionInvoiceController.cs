// using Forpost.Features.InvoiceManagment.CompositionInvoice;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.InvoiceManagement.CompositionInvoices;
//
// public sealed class CompositionInvoiceController: ApiController
// {
//     /// <summary>
//     /// Список готовых продуктов, подходящих под счет
//     /// </summary>
//     /// <param name="invoiceId"></param>
//     /// <param name="cancellationToken"></param>
//     /// <returns></returns>
//     [HttpGet]
//     public async Task<IReadOnlyCollection<CompositionInvoiceResponse>>
//         GetRelevantProducts(Guid invoiceId, Guid productId, CancellationToken cancellationToken) 
//         => Mapper.Map<IReadOnlyCollection<CompositionInvoiceResponse>>
//             (await Sender.Send(new GetRelevantProductsQuery(invoiceId, productId), cancellationToken));
// }