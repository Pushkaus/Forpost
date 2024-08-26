using AutoMapper;
using Forpost.Domain.Sortout;

namespace Forpost.Application.SortOut;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateCommand, Invoice>().ValidateMemberList(MemberList.Destination);
    }
}