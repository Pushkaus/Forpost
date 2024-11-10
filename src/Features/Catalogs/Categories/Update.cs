using AutoMapper;
using Forpost.Domain.Catalogs.Category;
using Mediator;

namespace Forpost.Features.Catalogs.Categories;

internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(command);
        _domainRepository.Update(category);
        return ValueTask.FromResult(Unit.Value);
    }
}

public record UpdateCategoryCommand(Guid Id, string Name, Guid? ParentCategoryId, string? Description) : ICommand;