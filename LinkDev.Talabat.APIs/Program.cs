
using LinkDev.Talabat.APIs.Extensions;
using LinkDev.Talabat.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        #region ASK Runtime Env for an object from "StoreContext" service Implicitly
        #region 1. DI Via Constructor [Invalid]
        /*
        // Object member constructor for the Program class.
        // This constructor will only be called if we explicitly create a Program object.
        // Note: Since the Main method is static, this constructor is not called automatically.
        public Program(StoreContext dbContext)
        {

        }
        */
        #endregion

        #region 2. DI Via Static Constructor [Invalid]
        /*
        // Invalid: static constructors cannot take parameters
        static Program(StoreContext storeContext)
        {

        }
        */
        #endregion

        #region 3.DI via Main parameters  [Invalid]
        // public static void Main(string[] args,StoreContext dbContext)
        #endregion

        #region 4. DI Via Property  [Valid]
        //[FromServices]
        // public static StoreContext storeContext { get; set; } = null!;
        #endregion

        #endregion

        // Entry Point
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services

            // Add services to the container.
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Controller.Controllers.AssemblyInformation).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistanceServices(builder.Configuration);
            #endregion

            var app = builder.Build();

            #region Update-Database [ Apply Pending Migrations ] and Data Seeding

            #region 1.Manual Object Creation Method
            // StoreContext dbContext = new StoreContext(); 
            #endregion

            #region 2.Dependency Injection Method
            // Ask the CLR to create this Object
            // 5 ways to ask the CLR to create an Object
            //                                          4 Implicitly
            //                                          1 Ecplicitly
            #endregion



            #region ASK Runtime Env for an object from "StoreContext" service Explicitly
            // using var scope = app.Services.CreateAsyncScope(); // Create a new scope for dependency injection 
            // var Services = scope.ServiceProvider; // Get the service provider from the scope
            //                                       // var storeContext = Services.GetRequiredService<StoreContext>(); // Get the StoreContext service from the service provider
            // var storeContextInitializer = Services.GetRequiredService<IStoreContextInitializer>();
            // var ILoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            //// var logger = Services.GetRequiredService<ILogger<Program>>();
            #endregion

            //try
            //{
            //    // This condition is checked here because GetPendingMigration has lower time cost than Migrate
            //    //var pendingMigrations = storeContext.Database.GetPendingMigrations();
            //    //if (pendingMigrations.Any())
            //    //{
            //    //    await storeContext.Database.MigrateAsync(); // Update-Database
            //    //}
            //    //await StoreContextSeed.SeedAsync(storeContext); // Data Seeding

            //    await storeContextInitializer.InitializeAsync();

            //    await storeContextInitializer.SeedAsync();




            //}
            //catch (Exception ex)
            //{
            //    var logger = ILoggerFactory.CreateLogger<Program>();
            //    logger.LogError(ex, "An error has been occured during applying migrations or seeding data");
            //}
            ////finally
            ////{
            ////   // await storeContext.DisposeAsync();
            ////   // await scope.DisposeAsync(); // Dispose the scope to release the resources
            ////}
            ///

            await app.InitializeStoreContextAsync();

            #endregion

            #region Configure Kestrel Middlewares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();                   
            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
