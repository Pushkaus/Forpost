using Forpost.Domain.Catalogs.Products;
using Forpost.Store.Postgres;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Features.StorageManagement;

internal sealed class ScanBarcodesCommandHandler : ICommandHandler<ScanBarcodesCommand>
{
    private readonly IProductDomainRepository _productDomainRepository;
    private readonly ForpostContextPostgres _context;
    public ScanBarcodesCommandHandler(IProductDomainRepository productDomainRepository, ForpostContextPostgres context)
    {
        _productDomainRepository = productDomainRepository;
        _context = context;
    }

    public async ValueTask<Unit> Handle(ScanBarcodesCommand command, CancellationToken cancellationToken)
    {
        var barcodeCounts = command.Barcodes.GroupBy(b => b)
            .ToDictionary(g => g.Key, g => g.Count());

        foreach (var barcodeCount in barcodeCounts)
        {
            var barcode = barcodeCount.Key;
            var count = barcodeCount.Value;
        }
        return await new ValueTask<Unit>(Unit.Value);
    }
}

public record ScanBarcodesCommand(IReadOnlyCollection<string> Barcodes) : ICommand;