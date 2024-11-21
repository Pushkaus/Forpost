using System.Runtime.InteropServices;
using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Products;
using Mediator;
using Newtonsoft.Json;
using SkiaSharp;
using ZXing;
using ZXing.Common;

namespace Forpost.Features.Catalogs.Barcodes.ProductBarcodes;

internal sealed class
    GetBarcodeByProductIdQueryHandler : IQueryHandler<GetBarcodeByProductIdQuery, byte[]>
{
    private readonly IProductDomainRepository _productDomainRepository;
    private readonly ICategoryDomainRepository _categoryDomainRepository;

    public GetBarcodeByProductIdQueryHandler(IProductDomainRepository productDomainRepository,
        ICategoryDomainRepository categoryDomainRepository)
    {
        _productDomainRepository = productDomainRepository;
        _categoryDomainRepository = categoryDomainRepository;
    }

    public async ValueTask<byte[]> Handle(GetBarcodeByProductIdQuery query,
        CancellationToken cancellationToken)
    {
        var product = await _productDomainRepository.GetByIdAsync(query.ProductId, cancellationToken);
        if (product == null)
        {
            return Array.Empty<byte>();
        }

        var productQr = new ProductQrCodeModel
        {
            Id = product.Id,
            Name = product.Name,
        };

        var productQrJson = JsonConvert.SerializeObject(productQr);

        // Генерация QR-кода с использованием ZXing
        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Height = 250,
                Width = 250,
                Margin = 1,
            }
        };
        writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
        var pixelData = writer.Write(productQrJson);

        using (var bitmap =
               new SKBitmap(pixelData.Width, pixelData.Height, SKColorType.Bgra8888, SKAlphaType.Premul))
        {
            // Закрепление массива байтов в памяти
            var pixelsHandle = GCHandle.Alloc(pixelData.Pixels, GCHandleType.Pinned);
            try
            {
                bitmap.InstallPixels(bitmap.Info, pixelsHandle.AddrOfPinnedObject(), bitmap.Info.RowBytes);

                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var memoryStream = new MemoryStream())
                {
                    data.SaveTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            finally
            {
                pixelsHandle.Free();
            }
        }
    }
}

public record GetBarcodeByProductIdQuery(Guid ProductId) : IQuery<byte[]>;