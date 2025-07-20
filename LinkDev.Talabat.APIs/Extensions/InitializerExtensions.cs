using LinkDev.Talabat.Domain.Contracts;

namespace LinkDev.Talabat.APIs.Extensions
{
    public static class InitializerExtensions
    {
        public static async Task<WebApplication> InitializeStoreContextAsync(this WebApplication webApplication) 
        {
            using var scope = webApplication.Services.CreateAsyncScope(); 
            var Services = scope.ServiceProvider; 
            var storeContextInitializer = Services.GetRequiredService<IStoreContextInitializer>();
            var ILoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                await storeContextInitializer.InitializeAsync();
                await storeContextInitializer.SeedAsync();
            }
            catch (Exception ex)
            {
                var logger = ILoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error has been occured during applying migrations or seeding data");
            }
            return webApplication;
        }
    }
}
