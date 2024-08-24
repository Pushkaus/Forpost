using AutoMapper;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateModel, InvoiceEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateModel, InvoiceEntity>().ValidateMemberList(MemberList.Destination);
    }
}