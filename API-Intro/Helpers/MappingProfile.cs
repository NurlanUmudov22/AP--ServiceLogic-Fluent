using API_Intro.DTOs.Cities;
using API_Intro.DTOs.Countries;
using API_Intro.DTOs.Sliders;
using API_Intro.Models;
using AutoMapper;

namespace API_Intro.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Country, CountryDto>()
                .ForMember(dest=>dest.Date, opt => opt.MapFrom(src => src.CreatedDate));


            CreateMap<CountryCreateDto, Country>();

            CreateMap<CountryEditDto, Country>();


            CreateMap<CityCreateDto, City>();

            CreateMap<City, CityDto>()
              .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));


            CreateMap<SliderCreateDto, Slider>();

            CreateMap<Slider, SliderDto>();

            CreateMap<SliderEditDto, Slider>().ForMember(dest=> dest.Image, opt => opt.Condition(src =>(src.Image is not null)));


            //CreateMap<SliderEditDto, Slider>().ForPath(
            //    m => m.Image,
            //    opt =>
            //    {
            //        opt.Condition(
            //            s => s.Destination.Image != null
            //            );

            //        opt.MapFrom(s => s.Image);
            //    }

            //    );


        }
    }
}
