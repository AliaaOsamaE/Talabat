using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            if (!dbContext.Brands.Any())
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
                    //    await dbContext.Brands.AddAsync(brand); 
                    //}
                    await dbContext.Set<ProductBrand>().AddRangeAsync(brands);
                    await dbContext.SaveChangesAsync();
                }
               
            }
            if (!dbContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync(@"..\LinkDev.Talabat.Infrastucture.Persistance\Data\Seeds\Categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if(Categories is not null && Categories.Count > 0)
                {
                    //foreach(var category in Categories)
                    //{
                    //    await dbContext.Categories.AddAsync(category);
                    //}

                    await dbContext.Set<ProductCategory>().AddRangeAsync(Categories);
                    await dbContext.SaveChangesAsync();
                }
            }


            if (!dbContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\LinkDev.Talabat.Infrastucture.Persistance\Data\Seeds\Products.json");
                var Products =  JsonSerializer.Deserialize<List<Product>>(productsData);
                if(Products is not null && Products.Count > 0)
                {
                    await dbContext.Set<Product>().AddRangeAsync(Products);
                    await dbContext.SaveChangesAsync();
                }

            }
        }

    }
}
