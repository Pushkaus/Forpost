using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface ITechnologicalCardService: IBusinessService
{
    public Task<TechnologicalCard> GetTechnologicalCardByIdAsync(int id);
    
    
}