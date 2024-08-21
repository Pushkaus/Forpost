using AutoMapper;
using Forpost.Business.Models.Files;
using Forpost.Store.Entities;

namespace Forpost.Business.Mappers;

internal sealed class FileMapperProfile : Profile
{
    public FileMapperProfile()
    {
        CreateMap<UploadFileModel, FileEntity>().ValidateMemberList(MemberList.Destination);
        CreateMap<FileEntity, DownloadFileModel>()
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
            .ForMember(dest => dest.FileContent, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }
}