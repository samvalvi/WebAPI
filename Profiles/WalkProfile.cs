using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<Walk, UpdateWalkDTO>().ReverseMap();
            CreateMap<Walk, AddWalkDTO>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDTO>().ReverseMap();
        }
    }
}
