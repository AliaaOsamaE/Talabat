

namespace LinkDev.Talabat.Infrastucture.Persistance
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
            return services;
        }
    }
}
