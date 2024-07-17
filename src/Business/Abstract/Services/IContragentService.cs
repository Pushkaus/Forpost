using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IContragentService
{
    public Task Add(string name);
    public Task<IReadOnlyList<Contragent?>> GetAll();
    public Task<Contragent?> GetById(Guid id);
}