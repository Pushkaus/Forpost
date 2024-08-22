using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Products;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class ProductService : BaseBusinessService, IProductService
{
    public ProductService(IDbUnitOfWork dbUnitOfWork, 
        ILogger<ProductService> logger, 
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider) : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.ProductRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Guid> AddAsync(ProductCreateModel model, CancellationToken cancellationToken)
    {
        var product = Mapper.Map<Product>(model);
        DbUnitOfWork.ProductRepository.Add(product);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        //TODO:
        return Guid.Empty;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await DbUnitOfWork.ProductRepository.GetByIdAsync(id, cancellationToken);
        return product;
    }

    public async Task UpdateAsync(ProductUpdateModel model, CancellationToken cancellationToken)
    {
        var product = Mapper.Map<Product>(model);
        DbUnitOfWork.ProductRepository.Update(product);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.ProductRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}