using WebAPIMatricula_3C2023.Entities;
using WebAPIMatricula_3C2023.Models;
using AutoMapper;

namespace WebAPIMatricula_3C2023.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UserModel>();
            CreateMap<RegisterModel, Usuario>();
            CreateMap<UpdateModel, Usuario>();
        }
    }
}
