using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace E_Commerce.Infrastructure.Seeding
{
    public class CatalogDataSeeder(StoreDbContext dbContext, ILogger<CatalogDataSeeder> logger) : IDataSeeder
    {
        public async Task SeedAsync(CancellationToken ct = default)
        {
            try
            {
                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(ct);
                if(pendingMigrations.Any())
                
                    await dbContext.Database.MigrateAsync(ct);

                var SeedRoot = Path.Combine(AppContext.BaseDirectory, "DataSeed");
                await SeedIfEmpetyAsync<ProductBrand>(SeedRoot, "brands.json", ct);
                await SeedIfEmpetyAsync<Product>(SeedRoot, "products.json", ct);
                await SeedIfEmpetyAsync<ProductType>(SeedRoot, "types.json", ct);

                await dbContext.SaveChangesAsync(ct);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Catalog Data Seeding Failed");
                throw;
            }
        }
        private async Task SeedIfEmpetyAsync<T>(string root,string filename,CancellationToken ct=default) where T : class
        {
            if (await dbContext.Set<T>().AnyAsync(ct)) return;
            var path=Path.Combine(root, filename);
            if(!File.Exists(path))
            {
                logger.LogWarning("Seed File Not Found:{Path}",path);
                return;
            }
            await using var stream= File.OpenRead(path);
            var Items=await JsonSerializer.DeserializeAsync<List<T>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true },ct);

            if(Items?.Count() > 0)
            {
                await dbContext.Set<T>().AddRangeAsync(Items, ct);
                 
            }
        }
    }
}
