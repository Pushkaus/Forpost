using System.Collections;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface ISubProductService: IBusinessService
{
    public Task<string> AddSubProduct(string parentName, string daughterName, string unitOfMeasure, decimal quantity);
    public Task<IEnumerable> GetSubProductsByParent(string parentName);
}