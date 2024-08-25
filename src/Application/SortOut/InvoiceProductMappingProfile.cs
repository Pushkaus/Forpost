// using AutoMapper;
// using Forpost.Business.Catalogs.Products;
// using Forpost.Domain.Catalogs.Products;
// using Forpost.Store.Entities;
// using Forpost.Store.Repositories.Models.InvoiceProduct;
//
// namespace Forpost.Business.Sortout;
//
// internal sealed class InvoiceProductMappingProfile : Profile
// {
//     public InvoiceProductMappingProfile()
//     {
//         CreateMap<InvoiceProductCreate, InvoiceProduct>().ValidateMemberList(MemberList.Destination);
//         CreateMap<InvoiceWithProductsModel, InvoiceProduct>().ValidateMemberList(MemberList.Destination);
//         CreateMap<Product, InvoiceProduct>()
//             .ForMember(dest => dest.Name,
//                 opt => opt.MapFrom(src => src.Name));
//     }
// }