using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Features.CRM.InvoiceManagement.InvoiceProducts;
using Forpost.Features.CRM.InvoiceManagement.Invoices;

namespace Forpost.Features.CRM.InvoiceManagement;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<AddInvoiceCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddInvoiceProductCommand, InvoiceProduct>().ValidateMemberList(MemberList.Source);
    }
}