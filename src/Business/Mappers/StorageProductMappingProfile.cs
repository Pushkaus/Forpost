using AutoMapper;
using Forpost.Business.Models.StorageProduct;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public class StorageProductMappingProfile: Profile
{
    public StorageProductMappingProfile()
    {
        CreateMap<StorageProductCreateModel, StorageProduct>().ValidateMemberList(MemberList.Destination);
        CreateMap<StorageProduct, StorageProductModel>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.Storage.Name))
            .ValidateMemberList(MemberList.Destination);
    }
}