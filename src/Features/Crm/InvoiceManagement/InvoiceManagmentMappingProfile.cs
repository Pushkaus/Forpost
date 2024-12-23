using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Features.Crm.InvoiceManagement.InvoiceProducts;
using Forpost.Features.Crm.InvoiceManagement.Invoices;

namespace Forpost.Features.Crm.InvoiceManagement;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<AddInvoiceCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddInvoiceProductCommand, InvoiceProduct>().ValidateMemberList(MemberList.Source);
    }
}