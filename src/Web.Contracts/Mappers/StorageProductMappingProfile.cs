using AutoMapper;
using Forpost.Business.Sortout;
using Forpost.Web.Contracts.Models.StorageProduct;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class StorageProductMappingProfile : Profile
{
    public StorageProductMappingProfile()
    {
        CreateMap<StorageProductCreateRequest, StorageProductCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<StorageProduct, StorageProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}