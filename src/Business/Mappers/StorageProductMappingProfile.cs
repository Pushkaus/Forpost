using AutoMapper;
using Forpost.Business.Models.StorageProduct;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.StorageProduct;

namespace Forpost.Business.Mappers;

internal sealed class StorageProductMappingProfile : Profile
{
    public StorageProductMappingProfile()
    {
        CreateMap<StorageProductCreateModel, StorageProductEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductsOnStorage, StorageProductModel>().ValidateMemberList(MemberList.Destination);
        /*CreateMap<StorageProductEntity, StorageProductModel>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductEntity.Name))
            .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.StorageEntity.Name))
            .ValidateMemberList(MemberList.Destination);*/
    }
}