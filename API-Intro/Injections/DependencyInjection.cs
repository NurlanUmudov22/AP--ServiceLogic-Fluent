using API_Intro.Helpers;
using API_Intro.Models;
using API_Intro.Services;
using API_Intro.Services.Interfaces;

namespace API_Intro.Injections
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<ISliderService, SliderService>();

            return services;

        }

    }
}
