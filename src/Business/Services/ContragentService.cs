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

    public async Task AddAsync(string name, CancellationToken cancellationToken)
    {
        var contragent = new Contragent(name);
        await _contragentRepository.AddAsync(contragent, cancellationToken);
    }

    public async Task<IReadOnlyList<Contragent>> GetAllAsync(CancellationToken cancellationToken)
    {
        var contragents = await _contragentRepository.GetAllAsync(cancellationToken);
        
        return contragents;
    }

    public async Task<Contragent?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contragent = await _contragentRepository.GetByIdAsync(id, cancellationToken);
        if (contragent == null)
        {
            throw ForpostErrors.NotFound<Contragent>(id);
        }

        return contragent;
    }
}