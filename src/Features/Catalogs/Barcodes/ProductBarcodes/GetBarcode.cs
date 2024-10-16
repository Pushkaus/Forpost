using BarcodeStandard;
using Forpost.Domain.Catalogs.Barcodes;
using Forpost.Domain.Catalogs.Products;
using Mediator;
using SkiaSharp;

namespace Forpost.Features.Catalogs.Barcodes.ProductBarcodes
{
    internal sealed class
        GetBarcodeByProductIdQueryHandler : IQueryHandler<GetBarcodeByProductIdQuery, IReadOnlyCollection<SKImage>>
    {
        private readonly IProductBarcodeDomainRepository _productBarcodeDomainRepository;

        public GetBarcodeByProductIdQueryHandler(IProductBarcodeDomainRepository productBarcodeDomainRepository)
        {
            _productBarcodeDomainRepository = productBarcodeDomainRepository;
        }

        public async ValueTask<IReadOnlyCollection<SKImage>> Handle(GetBarcodeByProductIdQuery query,
            CancellationToken cancellationToken)
        {
            var productBarcodes =
                await _productBarcodeDomainRepository.GetByProductId(query.ProductId, cancellationToken);
            var images = new List<SKImage>();
            var b = new Barcode();
            b.IncludeLabel = true;
            foreach (var productBarcode in productBarcodes)
            {
                var img = b.Encode(BarcodeStandard.Type.Code128, productBarcode.Barcode,
                    SKColors.Black, SKColors.White,
                    290,
                    120);
                images.Add(img);
            }

            return images;
        }
    }

    public record GetBarcodeByProductIdQuery(Guid ProductId) : IQuery<IReadOnlyCollection<SKImage>>;
}