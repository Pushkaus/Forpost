using AutoMapper;
using Forpost.Application.InvoiceManagment.Invoices;
using Forpost.Web.Contracts.Models.Invoices;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateRequest, InvoiceCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateRequest, InvoiceUpdateCommand>().ValidateMemberList(MemberList.Destination);
    }
}