using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Models.InvoiceProduct;

namespace Forpost.Business.Sortout;

internal sealed class InvoiceProductMappingProfile : Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductCreate, InvoiceProductEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceWithProductsModel, InvoiceProduct>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductEntity, InvoiceProduct>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));
    }
}