using AutoMapper;
using Forpost.Business.Models.StorageProduct;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.StorageProduct;

namespace Forpost.Business.Mappers;

internal sealed class StorageProductMappingProfile : Profile
{
    public StorageProductMappingProfile()
    {
        CreateMap<StorageProductCreateModel, StorageProduct>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductsOnStorage, StorageProductModel>().ValidateMemberList(MemberList.Destination);
        /*CreateMap<StorageProduct, StorageProductModel>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.Storage.Name))
            .ValidateMemberList(MemberList.Destination);*/
    }
}