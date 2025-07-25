using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Mapping;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseLazyLoadingProxies();
            });

            services.AddAutoMapper(Mapper => Mapper.AddProfile(new MappingProfile()));
            //services.AddAutoMapper(Mapper => Mapper.AddProfile<MappingProfile>()));
            //services.AddAutoMapper(typeof(MappingProfile());
            //services.AddAutoMapper(typeof(MappingProfile().Assembly);
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
            return services;
        }
    }
}
