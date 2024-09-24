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
        }
    }
}
