using AutoMapper;
using Forpost.Business.Models.ProductOperations;
using Forpost.Store.Entities;

namespace Forpost.Web.Contracts.Mappers;

public class ProductOperationProfile: Profile
{
    public ProductOperationProfile()
    {
        CreateMap<OperationCreateModel, ProductOperation>().ValidateMemberList(MemberList.Destination);
    }
}