using AutoMapper;
using Forpost.Application.Catalogs.Operations;
using Forpost.Web.Contracts.Models.ProductOperations;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class ProductOperationProfile : Profile
{
    public ProductOperationProfile()
    {
        CreateMap<OperationCreateRequest, AddOperationCommand>().ValidateMemberList(MemberList.Destination);
    }
}