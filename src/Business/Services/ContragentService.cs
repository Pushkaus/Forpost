using Forpost.Business.Abstract.Services;
using Forpost.Common;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class ContragentService: IContragentService
{
    private readonly IContragentRepository _contragentRepository;

    public ContragentService(IContragentRepository contragentRepository)
    {
        _contragentRepository = contragentRepository;
    }

    public async Task Add(string name)
    {
        var contragent = new Contragent(name);
        await _contragentRepository.AddAsync(contragent);
    }

    public async Task<IReadOnlyList<Contragent>> GetAll()
    {
        var contragents = await _contragentRepository.GetAllAsync();
        
        return contragents;
    }

    public async Task<Contragent?> GetById(Guid id)
    {
        var contragent = await _contragentRepository.GetByIdAsync(id);
        if (contragent == null)
        {
            throw ForpostErrors.NotFound<Contragent>(id);
        }

        return contragent;
    }
}