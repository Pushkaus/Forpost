using AutoMapper;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;

namespace Forpost.Web.Contracts.Mappers;

public sealed class InvoiceMappingProfile: Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateModel, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateModel, Invoice>().ValidateMemberList(MemberList.Destination);
    }
}