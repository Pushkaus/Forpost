using AutoMapper;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

public sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateModel, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateModel, Invoice>().ValidateMemberList(MemberList.Destination);
    }
}