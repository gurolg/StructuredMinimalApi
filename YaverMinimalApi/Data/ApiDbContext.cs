using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Modules.Products.Entities;
using YaverMinimalApi.Modules.Todos.Entities;

namespace YaverMinimalApi.Data;

public class ApiDbContext : DbContext
{
	public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
	public DbSet<ToDoEntity> Todos => Set<ToDoEntity>();
	public DbSet<ProductEntity> Products => Set<ProductEntity>();

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<ToDoEntity>()
			.HasKey(t => t.Id);

		builder.Entity<ProductEntity>()
			.HasKey(t => t.Id);


		builder.Entity<ToDoEntity>().HasData(
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000000"), false) { Title = "Todo 1" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000001"), false) { Title = "Todo 2" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000002"), false) { Title = "Todo 3" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000003"), false) { Title = "Todo 4" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000004"), false) { Title = "Todo 5" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000005"), false) { Title = "Todo 6" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000006"), false) { Title = "Todo 7" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000007"), false) { Title = "Todo 8" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000008"), false) { Title = "Todo 9" },
		 new ToDoEntity(new Guid("00000000-ffff-ffff-ffff-000000000009"), false) { Title = "Todo 10" }
	 );

		builder.Entity<ProductEntity>().HasData(
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000000"), false) { Title = "Product 1" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000001"), false) { Title = "Product 2" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000002"), false) { Title = "Product 3" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000003"), false) { Title = "Product 4" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000004"), false) { Title = "Product 5" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000005"), false) { Title = "Product 6" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000006"), false) { Title = "Product 7" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000007"), false) { Title = "Product 8" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000008"), false) { Title = "Product 9" },
		 new ProductEntity(new Guid("00000000-ffff-ffff-ffff-000000000009"), false) { Title = "Product 10" }
	 );
		base.OnModelCreating(builder);
	}
}