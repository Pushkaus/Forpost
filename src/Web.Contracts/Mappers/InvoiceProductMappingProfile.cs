using AutoMapper;
using Forpost.Application.InvoiceManagment.InvoiceProducts;
using Forpost.Domain.SortOut;
using Forpost.Web.Contracts.Models.InvoiceProducts;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class InvoiceProductMappingProfile : Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductRequest, InvoiceProductCreate>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceProduct, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}