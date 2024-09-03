using AutoMapper;
using Forpost.Domain.InvoiceManagement;
using Forpost.Domain.SortOut;
using Forpost.Features.InvoiceManagment.InvoiceProducts;
using Forpost.Features.InvoiceManagment.Invoices;

namespace Forpost.Features.InvoiceManagment;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        CreateMap<AddInvoiceCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<AddInvoiceProductCommand, InvoiceProduct>().ValidateMemberList(MemberList.Source);
    }
}