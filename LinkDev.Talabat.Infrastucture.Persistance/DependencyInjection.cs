
using LinkDev.Talabat.Infrastructure.Persistence.Data;

namespace LinkDev.Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(
                 optionsBuilder =>
                 {
                     optionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreContext"));
                 } 
                 /*,ServiceLifetime.Scoped, 
                  * ServiceLifetime.Scoped*/
                 );
            // services.AddScoped<IStoreContextInitializer,StoreContextInitializer>();
            services.AddScoped(typeof(IStoreContextInitializer), typeof(StoreContextInitializer));
            return services;
        }
    }
}
