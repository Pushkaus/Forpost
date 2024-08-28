using AutoMapper;
using Forpost.Application.InvoiceManagment.InvoiceProducts;
using Forpost.Application.InvoiceManagment.Invoices;
using Forpost.Domain.InvoiceManagement;

namespace Forpost.Application.InvoiceManagment;

internal sealed class InvoiceMappingProfile : Profile
{
    public InvoiceMappingProfile()
    {
        //
        CreateMap<AddInvoiceCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceUpdateCommand, Invoice>().ValidateMemberList(MemberList.Destination);
        //
        CreateMap<AddInvoiceProductCommand, InvoiceProduct>().ValidateMemberList(MemberList.Source);

    }
}