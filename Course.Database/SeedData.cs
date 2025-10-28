using Course.Database.Entity.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Course.Database;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();

        db.Database.Migrate();

        SeedData(db);
    }

    public static void SeedData(InventoryDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Categories.Any())
        {
            var items = new List<Category>
            {
                new Category
                {
                    Id = "a80b04f2-7732-48a0-ae9a-7bc58b156a6c",
                    Title = "Default Category",
                },
            };

            context.Categories.AddRange(items);
            context.SaveChanges();
        }
    }
}
