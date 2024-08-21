using AutoMapper;
using Forpost.Business.Models.Files;
using Forpost.Web.Contracts.Models.Files;

namespace Forpost.Web.Contracts.Mappers;

internal sealed class FileMapperProfile : Profile
{
    public FileMapperProfile()
    {
        CreateMap<UploadFileRequest, UploadFileModel>()
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.File.ContentType))
            .ForMember(dest => dest.Content, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
        CreateMap<DownloadFileModel, DownloadFileResponse>().ValidateMemberList(MemberList.Destination);
    }
}