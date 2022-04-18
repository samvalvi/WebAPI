using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDTO>().ReverseMap();
            CreateMap<WalkDifficulty, UpdateWalkDifficultyDTO>().ReverseMap();
            CreateMap<WalkDifficulty, AddWalkDifficultyDTO>().ReverseMap();
        }
    }
}
