using AutoMapper;
using Forpost.Application.Contracts.InvoiceManagment.InvoiceProducts;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Web.Contracts.CRM.InvoiceManagement.InvoiceProducts;

namespace Forpost.Web.Contracts.CRM.InvoiceManagement;

internal sealed class InvoiceManagementMappingProfile : Profile
{
    public InvoiceManagementMappingProfile()
    {
        CreateMap<InvoiceProduct, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceWithProductsModel, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}