using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.StorageProduct;

namespace Forpost.Business.Sortout;

internal sealed class StorageProductMappingProfile : Profile
{
    public StorageProductMappingProfile()
    {
        CreateMap<StorageProductCreateCommand, StorageProductEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<ProductsOnStorageModel, StorageProduct>().ValidateMemberList(MemberList.Destination);
        /*CreateMap<StorageProductEntity, StorageProduct>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductEntity.Name))
            .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.StorageEntity.Name))
            .ValidateMemberList(MemberList.Destination);*/
    }
}