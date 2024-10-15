using AutoMapper;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Features.InvoiceManagement.InvoiceProducts;
using Forpost.Features.InvoiceManagement.Invoices;

namespace Forpost.Features.InvoiceManagement;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<AddInvoiceCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddInvoiceProductCommand, InvoiceProduct>().ValidateMemberList(MemberList.Source);
    }
}