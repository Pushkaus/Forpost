using AutoMapper;
using Forpost.Features.FileStorage.Files;
using File = Forpost.Domain.FileStorage.File;


namespace Forpost.Features.FileStorage;

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