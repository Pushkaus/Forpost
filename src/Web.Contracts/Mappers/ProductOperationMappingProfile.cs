using AutoMapper;
using Forpost.Business.Models.ProductOperations;
using Forpost.Web.Contracts.Models.ProductOperations;

namespace Forpost.Web.Contracts.Mappers;

public class ProductOperationMappingProfile : Profile
{
    public ProductOperationMappingProfile()
    {
        CreateMap<OperationCreateRequest, OperationCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}