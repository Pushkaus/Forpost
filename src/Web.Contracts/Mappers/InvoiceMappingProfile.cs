using AutoMapper;
using Forpost.Business.Models.Invoices;
using Forpost.Web.Contracts.Models.Invoices;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<InvoiceCreateRequest, InvoiceCreateModel>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateRequest, InvoiceUpdateModel>().ValidateMemberList(MemberList.Destination);
    }
}