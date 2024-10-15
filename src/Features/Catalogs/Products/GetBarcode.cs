using BarcodeStandard;
using Forpost.Domain.Catalogs.Products;
using Mediator;
using SkiaSharp;


namespace Forpost.Features.Catalogs.Products
{
    internal sealed class
        GetBarcodeByProductIdQueryHandler : IQueryHandler<GetBarcodeByProductIdQuery, SKImage>
    {
        private readonly IProductDomainRepository _productDomainRepository;

        public GetBarcodeByProductIdQueryHandler(IProductDomainRepository productDomainRepository)
        {
            _productDomainRepository = productDomainRepository;
        }

        public async ValueTask<SKImage> Handle(GetBarcodeByProductIdQuery query,
            CancellationToken cancellationToken)
        {
            var product = await _productDomainRepository.GetByIdAsync(query.ProductId, cancellationToken);
            var b = new Barcode();
            b.IncludeLabel = true;
            var img = b.Encode(BarcodeStandard.Type.Code128, product.Barcode, SKColors.Black, SKColors.White, 290, 120);
            return img;
        }
    }

    public record GetBarcodeByProductIdQuery(Guid ProductId) : IQuery<SKImage>;
}