using AutoMapper;
using Forpost.Application.Catalogs.Storages;
using Forpost.Domain.Catalogs.Storages;
using Forpost.Web.Contracts.Models.Storages;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class StorageMappingProfile : Profile
{
    public StorageMappingProfile()
    {
        CreateMap<StorageCreateRequest, AddStorageCommand>().ValidateMemberList(MemberList.Destination);
    }
}