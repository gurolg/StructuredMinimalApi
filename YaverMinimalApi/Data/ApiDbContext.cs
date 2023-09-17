using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Features.Products.Entities;
using YaverMinimalApi.Features.Todo.Entities;

namespace YaverMinimalApi.Data;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TaskEntity>()
            .HasKey(t => t.Id);

        builder.Entity<ProductEntity>()
            .HasKey(t => t.Id);


        builder.Entity<TaskEntity>().HasData(
            new TaskEntity() { Id = NewGuid(1), IsComplete = false, Title = "Todo 1" },
            new TaskEntity() { Id = NewGuid(2), IsComplete = false, Title = "Todo 2" },
            new TaskEntity() { Id = NewGuid(3), IsComplete = false, Title = "Todo 3" },
            new TaskEntity() { Id = NewGuid(4), IsComplete = false, Title = "Todo 4" },
            new TaskEntity() { Id = NewGuid(5), IsComplete = false, Title = "Todo 5" },
            new TaskEntity() { Id = NewGuid(6), IsComplete = false, Title = "Todo 6" },
            new TaskEntity() { Id = NewGuid(7), IsComplete = false, Title = "Todo 7" },
            new TaskEntity() { Id = NewGuid(8), IsComplete = false, Title = "Todo 8" },
            new TaskEntity() { Id = NewGuid(9), IsComplete = false, Title = "Todo 9" }
        );

        builder.Entity<ProductEntity>().HasData(
            new ProductEntity { Id = NewGuid(1), IsOutOfStock = false, Title = "Product 1" },
            new ProductEntity { Id = NewGuid(2), IsOutOfStock = false, Title = "Product 2" },
            new ProductEntity { Id = NewGuid(3), IsOutOfStock = false, Title = "Product 3" },
            new ProductEntity { Id = NewGuid(4), IsOutOfStock = false, Title = "Product 4" },
            new ProductEntity { Id = NewGuid(5), IsOutOfStock = false, Title = "Product 5" },
            new ProductEntity { Id = NewGuid(6), IsOutOfStock = false, Title = "Product 6" },
            new ProductEntity { Id = NewGuid(7), IsOutOfStock = false, Title = "Product 7" },
            new ProductEntity { Id = NewGuid(8), IsOutOfStock = false, Title = "Product 8" },
            new ProductEntity { Id = NewGuid(9), IsOutOfStock = false, Title = "Product 9" }
        );
        base.OnModelCreating(builder);
    }

    private static Guid NewGuid(int i)
    {
        return new Guid(i.ToString().PadLeft(32, '0'));

    }
}