using AutoMapper;
using Forpost.Application.Contracts.Issues;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.ProductCreating.Issue;
using Forpost.Domain.ProductCreating.ProductDevelopment;

namespace Forpost.Features.ProductCreating;

internal sealed class ProductCreatingMappingProfile : Profile
{
    public ProductCreatingMappingProfile()
    {
        CreateMap<ScheduledIssue, Issue>().ValidateMemberList(MemberList.Source);
        CreateMap<InizializationProductDevelopment, ProductDevelopment>().ValidateMemberList(MemberList.Source);
    }
}