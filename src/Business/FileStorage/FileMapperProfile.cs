using AutoMapper;
using Forpost.Store.Entities;

namespace Forpost.Business.FileStorage;

internal sealed class FileMapperProfile : Profile
{
    public FileMapperProfile()
    {
        CreateMap<UploadFileCommand, FileEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<FileEntity, DownloadFileCommand>()
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
            .ForMember(dest => dest.FileContent, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }
}