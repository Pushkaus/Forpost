using Forpost.Domain.Catalogs.Category;
using Mediator;

namespace Forpost.Features.Catalogs.Categories;

internal sealed class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand, Guid>
{
    private readonly ICategoryDomainRepository _categoryDomainRepository;

    public AddCategoryCommandHandler(ICategoryDomainRepository categoryDomainRepository)
    {
        _categoryDomainRepository = categoryDomainRepository;
    }

    public ValueTask<Guid> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = command.Name,
            Description = command.Description,
            ParentCategoryId = command.ParentCategoryId,
        };
        var categoryId = _categoryDomainRepository.Add(category);
        return ValueTask.FromResult(categoryId);
    }
}

public record AddCategoryCommand(string Name, Guid? ParentCategoryId, string? Description)
    : ICommand<Guid>;