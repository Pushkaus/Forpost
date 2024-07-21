using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class InvoiceProductService: IInvoiceProductService
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

    public async Task<IReadOnlyList<InvoiceProductModel?>> GetProductsById(Guid id)
    {
       var invoiceProducts = await _invoiceProductRepository.GetProductsById(id);
       var response = _mapper.Map<IReadOnlyList<InvoiceProductModel>>(invoiceProducts);
       return response;

    }

    public async Task Update(InvoiceProductCreateModel model)
    {
        var invoiceProduct = _mapper.Map<InvoiceProduct>(model);
        await _invoiceProductRepository.UpdateAsync(invoiceProduct);
    }

    public async Task DeleteByProductId(Guid id)
    {
        await _invoiceProductRepository.DeleteByProductId(id);
    }
}