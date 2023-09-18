using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;

using Microsoft.EntityFrameworkCore;

namespace Agrio.Todo.Service.Features.Entities;

public static class TaskQueries {

	public static readonly Func<ServiceDbContext, Guid, CancellationToken, Task<TaskEntity>>
		GetTaskByIdAsync = EF.CompileAsyncQuery((
			ServiceDbContext context,
			Guid id,
			CancellationToken ct) => context
				.Tasks
				.Where(m => m.Id == id)
				.FirstOrDefault());


	// public static readonly Func<ServiceDbContext, CancellationToken, IAsyncEnumerable<TaskEntity>> GetTasksAsync =
	// 		EF.CompileAsyncQuery((
	// 			ServiceDbContext ctx,
	// 			CancellationToken ct) => ctx.Tasks
	// 				.AsNoTracking()
	// 				.Where(m => !m.IsComplete));

}