using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Features.CRM.InvoiceManagement.Invoices;
using Forpost.Features.InvoiceManagement.InvoiceProducts;

namespace Forpost.Features.CRM.InvoiceManagement;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<AddInvoiceCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddInvoiceProductCommand, InvoiceProduct>().ValidateMemberList(MemberList.Source);
    }
}