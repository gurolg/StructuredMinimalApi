using Agrio.Todo.Service.Features.Entities;

using Microsoft.EntityFrameworkCore;

namespace Agrio.Todo.Service.Data;

public class ServiceDbContext(DbContextOptions<ServiceDbContext> options) : DbContext(options) {
	public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

	protected override void OnModelCreating(ModelBuilder builder) {
		builder.Entity<TaskEntity>()
			.HasKey(t => t.Id);

		builder.Entity<TaskEntity>().HasData(
			new TaskEntity { Id = NewGuid(1), IsComplete = false, Title = "Todo 1" },
			new TaskEntity { Id = NewGuid(2), IsComplete = false, Title = "Todo 2" },
			new TaskEntity { Id = NewGuid(3), IsComplete = false, Title = "Todo 3" },
			new TaskEntity { Id = NewGuid(4), IsComplete = false, Title = "Todo 4" },
			new TaskEntity { Id = NewGuid(5), IsComplete = false, Title = "Todo 5" },
			new TaskEntity { Id = NewGuid(6), IsComplete = false, Title = "Todo 6" },
			new TaskEntity { Id = NewGuid(7), IsComplete = false, Title = "Todo 7" },
			new TaskEntity { Id = NewGuid(8), IsComplete = false, Title = "Todo 8" },
			new TaskEntity { Id = NewGuid(9), IsComplete = false, Title = "Todo 9" }
		);

		base.OnModelCreating(builder);
	}

	private static Guid NewGuid(int i) {
		return new Guid(i.ToString().PadLeft(32, '0'));
	}
}
