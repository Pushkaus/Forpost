using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface ISubProductRepository
{
    public Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity);
    public Task<IEnumerable> GetSubProductsByParent(string parentName);

}