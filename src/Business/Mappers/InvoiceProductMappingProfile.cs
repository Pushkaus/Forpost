using AutoMapper;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public class InvoiceProductMappingProfile: Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductCreateModel, InvoiceProduct>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceProduct, InvoiceProductModel>().ValidateMemberList(MemberList.Destination);
    }
}