using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagement.Invoices;

internal sealed class InvoiceShipCommandHandler: ICommandHandler<ShipInvoiceCommand>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    private readonly IMapper _mapper;
    public InvoiceShipCommandHandler(IInvoiceDomainRepository invoiceDomainRepository, IMapper mapper)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Unit> Handle(ShipInvoiceCommand command, CancellationToken cancellationToken)
    {
        //TODO; Нельзя отгрузить счет, если процент оплаты меньше 100 и если нет состава счета.
        var invoice = _mapper.Map<Invoice>(await _invoiceDomainRepository.GetByIdAsync(command.InvoiceId, cancellationToken));
        
        invoice.Ship(command.ShipDate.UtcDateTime);
        

        _invoiceDomainRepository.Update(invoice);
        return await ValueTask.FromResult(Unit.Value);

    }
}
public record ShipInvoiceCommand(Guid InvoiceId, DateTimeOffset ShipDate): ICommand;