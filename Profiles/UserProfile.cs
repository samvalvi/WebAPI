using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, AddUserDTO>().ReverseMap();
        }
    }
}
