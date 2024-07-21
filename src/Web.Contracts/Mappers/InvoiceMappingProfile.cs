using AutoMapper;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Repositories;
using Forpost.Web.Contracts.Models.Invoices;

namespace Forpost.Web.Contracts.Mappers;

public class InvoiceMappingProfile: Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateRequest, InvoiceCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateRequest, InvoiceUpdateModel>().ValidateMemberList(MemberList.Destination);
    }
}