using AutoMapper;
using Forpost.Business.Models.ProductOperations;
using Forpost.Web.Contracts.Models.ProductOperations;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class ProductOperationProfile : Profile
{
    public ProductOperationProfile()
    {
        CreateMap<OperationCreateRequest, OperationCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}