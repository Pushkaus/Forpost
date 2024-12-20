using AutoMapper;
using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class UpdateTechCardCommandHandler: ICommandHandler<UpdateTechCardCommand>
{
    private readonly ITechCardDomainRepository _techCardRepository;
    private readonly IMapper _mapper;
    
    public UpdateTechCardCommandHandler(ITechCardDomainRepository techCardRepository, IMapper mapper)
    {
        _techCardRepository = techCardRepository;
        _mapper = mapper;
    }

    public async ValueTask<Unit> Handle(UpdateTechCardCommand command, CancellationToken cancellationToken)
    {
        // Получаем существующую тех. карту из репозитория
        var existingTechCard = await _techCardRepository.GetByIdAsync(command.Id, cancellationToken);

        existingTechCard.UpdateDetails(command.Number, command.Description, command.ProductId);

        // Сохраняем изменения в репозитории
        _techCardRepository.Update(existingTechCard);

        return Unit.Value;
    }

}
public record UpdateTechCardCommand(Guid Id, string Number, string? Description, Guid ProductId) : ICommand;
