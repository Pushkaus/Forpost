using System.Collections;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.ProductOperation;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class ProductOperationRepository : IProductOperationRepository
{
    private readonly ForpostContextPostgres _db;

    public ProductOperationRepository(ForpostContextPostgres db)
    {
        _db = db;
    }

    public async Task<string> AddOperationAsync(Guid userId, string productName, string name, string? description,
        decimal? operationTime,
        decimal? cost)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Name == productName);
        var operationOnProduct = new ProductOperation()
        {
            ProductId = product.Id,
            Name = name,
            Description = description,
            OperationTime = operationTime,
            Cost = cost,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
            CreatedById = userId,
            UpdatedById = userId
        };
        await _db.ProductOperations.AddAsync(operationOnProduct);
        await _db.SaveChangesAsync();
        return "Операция над продуктом добавлена";
    }

    public async Task<IEnumerable<GerProductOperations>> GetAllOperationOnProduct(string productName)
    {
        var operations = await _db.ProductOperations
            .Include(po => po.Product) // Предварительная загрузка связанного продукта
            .Where(po => po.Product.Name == productName)
            .ToListAsync();

        var operationDtos = operations.Select(po => new GerProductOperations
        {
            Id = po.Id,
            ProductId = po.ProductId,
            Name = po.Name,
            Description = po.Description,
            OperationTime = po.OperationTime,
            Cost = po.Cost,
            ProductName = po.Product.Name // Заполнение поля с именем продукта
        });

        return operationDtos;

    }

}
