using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

public class InvoiceProductService: IInvoiceProductService
{
    private readonly IInvoiceProductRepository _invoiceProductRepository;
    private readonly IMapper _mapper;
    public InvoiceProductService(IInvoiceProductRepository invoiceProductRepository, IMapper mapper)
    {
        _invoiceProductRepository = invoiceProductRepository;
        _mapper = mapper;
    }
    public async Task Add(InvoiceProductCreateModel model)
    {
        var invoiceProduct = _mapper.Map<InvoiceProduct>(model);
        await _invoiceProductRepository.AddAsync(invoiceProduct);
    }

    public Task<IReadOnlyList<InvoiceProduct?>> GetProductsById(Guid id)
    {
        return null;
    }
}