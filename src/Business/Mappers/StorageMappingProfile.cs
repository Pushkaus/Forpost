using AutoMapper;
using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public class StorageMappingProfile : Profile
{
    public StorageMappingProfile()
    {
        CreateMap<StorageCreateModel, Storage>().ValidateMemberList(MemberList.Destination);
    }
}