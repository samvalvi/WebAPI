using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, UpdateRoleDTO>().ReverseMap();
            CreateMap<Role, AddRoleDTO>().ReverseMap();
        }
    }
}
