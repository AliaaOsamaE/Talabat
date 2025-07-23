using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Mapper => Mapper.AddProfile(new MappingProfile()));
            //services.AddAutoMapper(Mapper => Mapper.AddProfile<MappingProfile>()));
            //services.AddAutoMapper(typeof(MappingProfile());
            //services.AddAutoMapper(typeof(MappingProfile().Assembly);
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
            return services;
        }
    }
}
