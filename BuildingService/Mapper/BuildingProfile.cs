using AutoMapper;
using BuildingServiceGrpc;
using BuildingServices.Models;
using Google.Protobuf.WellKnownTypes;

namespace BuildingService.Mapper
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingModel>()
                .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.PurchaseDate)));

            CreateMap<BuildingModel, Building>()
                .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.CreatedTime.ToDateTime()));
        }
    }
}
