using AutoMapper;
using Forpost.Business.Catalogs.Storages;
using Forpost.Web.Contracts.Models.Storages;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class StorageMappingProfile : Profile
{
    public StorageMappingProfile()
    {
        CreateMap<StorageCreateRequest, StorageCreateCommand>().ValidateMemberList(MemberList.Destination);
    }
}