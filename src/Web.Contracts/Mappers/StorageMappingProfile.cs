using AutoMapper;
using Forpost.Business.Models.Storages;
using Forpost.Web.Contracts.Models.Storages;

namespace Forpost.Web.Contracts.Mappers;

public class StorageMappingProfile : Profile
{
    public StorageMappingProfile()
    {
        CreateMap<StorageCreateRequest, StorageCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}