using AutoMapper;
using Forpost.Store.Entities;

namespace Forpost.Business.Sortout;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateCommand, InvoiceEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateCommand, InvoiceEntity>().ValidateMemberList(MemberList.Destination);
    }
}