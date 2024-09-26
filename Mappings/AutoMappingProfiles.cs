using AutoMapper;
using Dotnet_v8.Models.Domain;
using Dotnet_v8.Models.DTOs;

namespace Dotnet_v8.Mappings
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<Walk,AddWalkRequestDto>().ReverseMap();   
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
