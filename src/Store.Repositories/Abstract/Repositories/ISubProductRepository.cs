namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface ISubProductRepository
{
    public Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity);
}