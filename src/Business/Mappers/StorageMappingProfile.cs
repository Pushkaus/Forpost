using AutoMapper;
using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Mappers;

internal sealed class StorageMappingProfile : Profile
{
    public StorageMappingProfile()
    {
        CreateMap<StorageCreateModel, Storage>().ValidateMemberList(MemberList.Destination);
    }
}