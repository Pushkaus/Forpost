using AutoMapper;
using Forpost.Application.InvoiceManagment.InvoiceProducts;
using Forpost.Application.InvoiceManagment.Invoices;
using Forpost.Domain.InvoiceManagment;
using Forpost.Domain.Sortout;

namespace Forpost.Application.SortOut;

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