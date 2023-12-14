using AutoMapper;
using CIronPy.Model;

namespace CIronPy.Dto
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<UserFileDto, UserFile>();
            CreateMap<UserFile, UserFileDto>();
            CreateMap<AdminDto, Admin>();
            CreateMap<Admin, AdminDto>();
            CreateMap<DataEmbeddingDto, DataEmbedding>();
            CreateMap<DataEmbedding, DataEmbeddingDto>();
        }
    }
}
