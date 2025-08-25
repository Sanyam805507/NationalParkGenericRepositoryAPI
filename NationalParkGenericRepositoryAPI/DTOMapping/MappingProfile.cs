using AutoMapper;
using NationalParkGenericRepositoryAPI.DTOs;
using NationalParkGenericRepositoryAPI.Models;

namespace NationalParkGenericRepositoryAPI.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TrailDTO, Trail>().ReverseMap();
            CreateMap<NationalPark, NationalParkDTO>().ReverseMap();
        }
    }
    // SERVER----DB---MODEL---REPOSITORY----DTO----CLIENT
     // CLIENT----DTO----REPOSITORY----MODEL----DB----SERVER
}

