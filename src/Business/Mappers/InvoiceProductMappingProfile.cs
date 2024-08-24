using AutoMapper;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.InvoiceProduct;

namespace Forpost.Business.Mappers;

internal sealed class InvoiceProductMappingProfile : Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductCreateModel, InvoiceProductEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceWithProducts, InvoiceProductModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductEntity, InvoiceProductModel>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));
    }
}