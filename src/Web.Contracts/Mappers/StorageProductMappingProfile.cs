using AutoMapper;
using Forpost.Business.Models.StorageProduct;
using Forpost.Web.Contracts.Models.StorageProduct;

namespace Forpost.Web.Contracts.Mappers;

public class StorageProductMappingProfile : Profile
{
    public StorageProductMappingProfile()
    {
        CreateMap<StorageProductCreateRequest, StorageProductCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<StorageProductModel, StorageProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}