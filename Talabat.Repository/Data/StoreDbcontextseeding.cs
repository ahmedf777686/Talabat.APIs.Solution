using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static   class StoreDbcontextseeding
    {

        public async static  Task Seedasync(StoreContext context)
        {

            // ProductBrand seeding
            if (!context.ProductBrands.Any())
            {
                var BrandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var Brand = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if (Brand is not null)
                {
                    foreach (var item in Brand)
                    {
                        await context.Set<ProductBrand>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                } 
            }



            // ProductCategories seeding
            if (!context.ProductCategories.Any())
            {
                var Categorysdata = File.ReadAllText("../Talabat.Repository/Data/DataSeed/categories.json");
                var Categorys = JsonSerializer.Deserialize<List<ProductCategory>>(Categorysdata);
                if(Categorys is not null)
                {
                    foreach (var item in Categorys)
                    {
                       await context.Set<ProductCategory>().AddAsync(item);
                    }

                  await  context.SaveChangesAsync();
                }

            }



            // Products seeding

            if (!context.Products.Any())
            {
                var Productsdata = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(Productsdata);

                if(products is not null)
                {
                    foreach (var item in products)
                    {
                      await  context.Set<Product>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            
            }
        }

    }
}
