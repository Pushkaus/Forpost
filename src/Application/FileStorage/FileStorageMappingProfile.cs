using AutoMapper;
using Forpost.Application.FileStorage.Files;
using File = Forpost.Domain.FileStorage.File;


namespace Forpost.Application.FileStorage;

internal sealed class FileStorageMappingProfile : Profile
{
    public FileStorageMappingProfile()
    {
        CreateMap<UploadFileCommand, File>().ValidateMemberList(MemberList.Destination);
        CreateMap<File, FileModel>()
            .ForMember(dest => dest.FileContent, opt => opt.Ignore())
            .ValidateMemberList(MemberList.Destination);
    }
}