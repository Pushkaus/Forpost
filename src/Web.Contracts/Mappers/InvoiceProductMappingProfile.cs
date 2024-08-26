using AutoMapper;
using Forpost.Application.SortOut;
using Forpost.Web.Contracts.Models.InvoiceProducts;
using InvoiceProduct = Forpost.Domain.Sortout.InvoiceProduct;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class InvoiceProductMappingProfile : Profile
{
    public InvoiceProductMappingProfile()
    {
        CreateMap<InvoiceProductRequest, InvoiceProductCreate>().ValidateMemberList(MemberList.Destination);
        CreateMap<InvoiceProduct, InvoiceProductResponse>().ValidateMemberList(MemberList.Destination);
    }
}