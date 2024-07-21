using AutoMapper;
using Forpost.Business.Models.ProductOperations;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public class ProductOperationMappingProfile: Profile
{
    public ProductOperationMappingProfile()
    {
        CreateMap<OperationCreateModel, ProductOperation>().ValidateMemberList(MemberList.Destination);
    }
}