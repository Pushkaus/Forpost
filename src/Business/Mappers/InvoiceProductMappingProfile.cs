using AutoMapper;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;
using InvoiceProduct = Forpost.Store.Entities.InvoiceProduct;

namespace Forpost.Business.Mappers;

public class InvoiceProductMappingProfile : Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductCreateModel, InvoiceProduct>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceWithProducts, InvoiceProductModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<Product, InvoiceProductModel>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name));
    }
}