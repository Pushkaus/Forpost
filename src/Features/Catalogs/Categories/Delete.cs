using Forpost.Domain.Catalogs.Category;
using Mediator;

namespace Forpost.Features.Catalogs.Categories;

internal sealed class DeleteCategoryCommandHandler: ICommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryDomainRepository _categoryDomainRepository;

    public DeleteCategoryCommandHandler(ICategoryDomainRepository categoryDomainRepository)
    {
        _categoryDomainRepository = categoryDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        _categoryDomainRepository.DeleteById(command.CategoryId);
        return Unit.ValueTask;
    }
}

public record DeleteCategoryCommand(Guid CategoryId) : ICommand; 