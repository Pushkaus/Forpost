using AutoMapper;
using Forpost.Business.Catalogs.ProductOperation;
using Forpost.Web.Contracts.Models.ProductOperations;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class ProductOperationProfile : Profile
{
    public ProductOperationProfile()
    {
        CreateMap<OperationCreateRequest, OperationCreateCommand>().ValidateMemberList(MemberList.Destination);
    }
}