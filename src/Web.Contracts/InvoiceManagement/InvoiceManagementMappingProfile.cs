using AutoMapper;
using Forpost.Application.InvoiceManagment.InvoiceProducts;
using Forpost.Application.InvoiceManagment.Invoices;
using Forpost.Domain.SortOut;
using Forpost.Web.Contracts.InvoiceManagement.InvoiceProducts;
using Forpost.Web.Contracts.InvoiceManagement.Invoices;

namespace Forpost.Web.Contracts.InvoiceManagement;

internal sealed class InvoiceManagementMappingProfile : Profile
{
    public InvoiceManagementMappingProfile()
    {
        CreateMap<InvoiceCreateRequest, InvoiceCreateCommand>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateRequest, InvoiceUpdateCommand>().ValidateMemberList(MemberList.Destination);
        
        CreateMap<InvoiceProductRequest, InvoiceProductCreate>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceProduct, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}