using Forpost.Domain.CRM.PriceLists;
using Mediator;

namespace Forpost.Features.CRM.PriceLists;

internal sealed class AddPriceListCommandHandler : ICommandHandler<AddPriceListCommand, Guid>
{
    private readonly IPriceListDomainRepository _priceListRepository;

    public AddPriceListCommandHandler(IPriceListDomainRepository priceListRepository)
    {
        _priceListRepository = priceListRepository;
    }

    public async ValueTask<Guid> Handle(AddPriceListCommand command, CancellationToken cancellationToken)
    {
        var priceList = new PriceList
        {
            OperationId = command.OperationId,
            ProductId = command.ProductId,
            Price = command.Price,
        };
        return _priceListRepository.Add(priceList);
    }
}

public record AddPriceListCommand(Guid OperationId, Guid ProductId, decimal Price) : ICommand<Guid>;