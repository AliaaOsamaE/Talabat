using LinkDev.Talabat.Domain.Contracts.Persistence;
using System.Text.Json;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
    internal class StoreContextInitializer (StoreContext _storeContext): IStoreContextInitializer
    {
        //private readonly StoreContext _storeContext;

        //public StoreContextInitializer(StoreContext storeContext)
        //{
        //    _storeContext = storeContext;
        //}
        public async Task InitializeAsync()
        {
            var pendingMigrations = _storeContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                await _storeContext.Database.MigrateAsync(); // Update-Database
            }
        }
        public async Task SeedAsync()
        {
            if (!_storeContext.Brands.Any())
            {
                var brandsData = await File.ReadAllTextAsync(@"..\LinkDev.Talabat.Infrastucture.Persistance\Data\Seeds\Brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                //    .Select(b => new ProductBrand
                //{
                //    Name = b.Name,
                //    CreatedBy = b.CreatedBy,
                //    CreatedOn = b.CreatedOn,
                //    LastModifiedBy = b.LastModifiedBy,
                //    LastModifiedOn = b.LastModifiedOn
                //});
                if (brands is not null && brands.Count > 0) // brands?.Count>0 [second option]
                {


                    //foreach (var brand in brands)
                    //{
                    //    await _storeContext.Brands.AddAsync(brand); 
                    //}
                    await _storeContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await _storeContext.SaveChangesAsync();
                }

            }
            if (!_storeContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync(@"..\LinkDev.Talabat.Infrastucture.Persistance\Data\Seeds\Categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (Categories is not null && Categories.Count > 0)
                {
                    //foreach(var category in Categories)
                    //{
                    //    await _storeContext.Categories.AddAsync(category);
                    //}

                    await _storeContext.Set<ProductCategory>().AddRangeAsync(Categories);
                    await _storeContext.SaveChangesAsync();
                }
            }
            if (!_storeContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\LinkDev.Talabat.Infrastucture.Persistance\Data\Seeds\Products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (Products is not null && Products.Count > 0)
                {
                    await _storeContext.Set<Product>().AddRangeAsync(Products);
                    await _storeContext.SaveChangesAsync();
                }

            }
        }
    }
}
