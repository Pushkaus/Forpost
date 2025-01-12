using AutoMapper;
using Forpost.Application.Contracts.CRM.InvoiceManagement.InvoiceProducts;
using Forpost.Domain.Crm.InvoiceManagement;
using Forpost.Web.Contracts.Crm.InvoiceManagement.InvoiceProducts;

namespace Forpost.Web.Contracts.Crm.InvoiceManagement;

internal sealed class InvoiceManagementMappingProfile : Profile
{
    public InvoiceManagementMappingProfile()
    {
        CreateMap<InvoiceProduct, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceWithProductsModel, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}