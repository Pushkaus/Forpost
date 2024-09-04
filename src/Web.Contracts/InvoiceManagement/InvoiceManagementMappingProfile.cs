using AutoMapper;
using Forpost.Application.Contracts.InvoiceProducts;
using Forpost.Domain.SortOut;
using Forpost.Features.InvoiceManagment.InvoiceProducts;
using Forpost.Features.InvoiceManagment.Invoices;
using Forpost.Web.Contracts.InvoiceManagement.InvoiceProducts;
using Forpost.Web.Contracts.InvoiceManagement.Invoices;

namespace Forpost.Web.Contracts.InvoiceManagement;

internal sealed class InvoiceManagementMappingProfile : Profile
{
    public InvoiceManagementMappingProfile()
    {
        
        CreateMap<InvoiceProductRequest, InvoiceProductCreate>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceProduct, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceWithProducts, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}