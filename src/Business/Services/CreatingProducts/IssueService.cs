using AutoMapper;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.Models.Issues;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Business.Services.CreatingProducts;

internal sealed class IssueService: IIssueService
{
    private readonly IIssueRepository _issueRepository;
    private readonly IMapper _mapper;

    public IssueService(IIssueRepository issueRepository, IMapper mapper)
    {
        _issueRepository = issueRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(IssueCreateModel model, CancellationToken cancellationToken)
    {
        var issue = _mapper.Map<Issue>(model);
        return await _issueRepository.AddAsync(issue, cancellationToken);
    }

    public async Task<Issue?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _issueRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IReadOnlyList<Issue>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _issueRepository.GetAllAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _issueRepository.DeleteByIdAsync(id, cancellationToken);
    }
}