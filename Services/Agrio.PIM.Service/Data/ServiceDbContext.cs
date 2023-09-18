using Agrio.PIM.Service.Features.Entities;

using Microsoft.EntityFrameworkCore;

namespace Agrio.PIM.Service.Data;

public class ServiceDbContext(DbContextOptions<ServiceDbContext> options) : DbContext(options) {
	public DbSet<ProductEntity> Products => Set<ProductEntity>();

	protected override void OnModelCreating(ModelBuilder builder) {
		builder.Entity<ProductEntity>()
			.HasKey(t => t.Id);


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

	private static Guid NewGuid(int i) {
		return new Guid(i.ToString().PadLeft(32, '0'));
	}
}
