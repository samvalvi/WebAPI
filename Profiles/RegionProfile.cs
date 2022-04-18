using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;

namespace WebAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, AddRegionDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();
        }
    }
}
