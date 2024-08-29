using AutoMapper;
using Forpost.Application.StorageManagment;
using Forpost.Web.Contracts.StorageManagement.StorageProduct;

namespace Forpost.Web.Contracts.StorageManagement;

internal sealed class StorageManagementMappingProfile : Profile
{
    public StorageManagementMappingProfile()
    {
        CreateMap<StorageProductCreateRequest, StorageProductCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<Domain.SortOut.StorageProduct, StorageProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}