using AutoMapper;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Web.Contracts.Models.InvoiceProducts;

namespace Forpost.Web.Contracts.Mappers;

public class InvoiceProductMappingProfile: Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductRequest, InvoiceProductCreateModel>().ValidateMemberList(MemberList.Destination);
    }
}