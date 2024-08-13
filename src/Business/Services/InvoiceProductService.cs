using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Events.Products;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using InvoiceProduct = Forpost.Store.Entities.InvoiceProduct;

namespace Forpost.Business.Services;

internal sealed class InvoiceProductService: IInvoiceProductService
{
    private readonly IInvoiceProductRepository _invoiceProductRepository;
    private readonly IDomainEventBus _eventBus;
    private readonly IMapper _mapper;
    public InvoiceProductService(IInvoiceProductRepository invoiceProductRepository, 
        IMapper mapper, IDomainEventBus eventBus)
    {
        _invoiceProductRepository = invoiceProductRepository;
        _mapper = mapper;
        _eventBus = eventBus;
    }
    public async Task AddAsync(InvoiceProductCreateModel model, CancellationToken cancellationToken)
    {
        var invoiceProduct = _mapper.Map<InvoiceProduct>(model);
        await _eventBus.PublishAsync(new ProductInInvoiceAdded()
        {
            InvoiceId = invoiceProduct.InvoiceId,
            ProductId = invoiceProduct.ProductId,
            Quantity = invoiceProduct.Quantity
        });
        await _invoiceProductRepository.AddAsync(invoiceProduct, cancellationToken);
    }

    public async Task<IReadOnlyList<InvoiceProductModel?>> 
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // await _eventBus.PublishAsync(new ProductInInvoiceAdded
        // {
        //     InvoiceId = id,
        //     ProductId = Guid.NewGuid(),
        //     Quantity = 1000
        // });
        //
        // await _eventBus.PublishAsync(new ProductInInvoiceAdded2
        // {
        //     InvoiceId = id,
        //     ProductId = Guid.NewGuid(),
        //     Quantity = 1000
        // });
        //
       var invoiceProducts = await _invoiceProductRepository.GetProductsByInvoiceIdAsync(id, cancellationToken);
       var response = _mapper.Map<IReadOnlyList<InvoiceProductModel>>(invoiceProducts);
       return response;

    }

    public async Task UpdateAsync(InvoiceProductCreateModel model, CancellationToken cancellationToken)
    {
        var invoiceProduct = _mapper.Map<InvoiceProduct>(model);
        await _invoiceProductRepository.UpdateAsync(invoiceProduct, cancellationToken);
    }

    public async Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _invoiceProductRepository.DeleteByProductIdAsync(id, cancellationToken);
    }
}