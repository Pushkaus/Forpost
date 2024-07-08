using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Models.Storages;

namespace Forpost.Business.Mappers;

public class StorageMappingProfile: Profile
{
    public StorageMappingProfile()
    {
        CreateMap<StorageCreateModel, Storage>().ValidateMemberList(MemberList.Destination);
    }
}