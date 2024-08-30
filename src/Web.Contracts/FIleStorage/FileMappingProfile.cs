using AutoMapper;
using Forpost.Features.FileStorage.Files;

namespace Forpost.Web.Contracts.FIleStorage;

internal sealed class FileMapperProfile : Profile
{
    public FileMapperProfile()
    {
        CreateMap<UploadFileRequest, UploadFileCommand>()
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.File.ContentType))
            .ForMember(dest => dest.Content, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
        CreateMap<DownloadFileQuery, DownloadFileResponse>().ValidateMemberList(MemberList.Destination);
    }
}