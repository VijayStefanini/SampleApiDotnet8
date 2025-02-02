using AutoMapper;
using SerilogDemo.Common.Enums;
using SerilogDemo.Common.UIModels;
using SerilogDemo.Data.Entities;
namespace SerilogDemoWebApi.Helpers
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestModel, Guest>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => (int)src.Title))
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => string.Join(",", src.PhoneNumbers)));

            CreateMap<Guest, GuestModel>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => (EnumUserTitle)src.Title))
            .ForMember(dest => dest.PhoneNumbers, 
                            opt => opt.MapFrom(src =>  src.PhoneNumbers.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()));
        }
    }
}
