using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

using Microsoft.EntityFrameworkCore;

namespace Agrio.Todo.Service.Features.Tasks.GetTasks;

public sealed class GetTasksCommandHandler(ServiceDbContext db) : ICommandHandler<GetTasksCommand, GetTasksResult> {
	public async Task<GetTasksResult> ExecuteAsync(GetTasksCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var tasks = await db.Tasks
			.AsNoTracking()
			.Where(t => string.IsNullOrEmpty(command.Term) || t.Title.Contains(command.Term))
			.ToListAsync(ct);

		var response = mapper.FromEntity(tasks);

		return response;
	}
}
