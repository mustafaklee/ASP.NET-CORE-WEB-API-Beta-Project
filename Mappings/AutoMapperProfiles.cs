using AutoMapper;
using MyFirstApiProject.Models.DTO;
using MyFirstApiProjects.Models.Domain;

namespace MyFirstApiProject.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Region veya RegionDto birbirine dönüşebilir.mapper objesini kullanırken hangisini başa yazdığımız önemli.
            CreateMap<Region,RegionDto>().ReverseMap();

            CreateMap<Region, RegionRequestDto>().ReverseMap();

            CreateMap<Region,UpdateRegionDto>().ReverseMap();

            CreateMap<Walk,WalkDto>().ReverseMap();

            CreateMap<Walk, WalkRequestDto>().ReverseMap();

            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
