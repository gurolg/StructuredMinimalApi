using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;

using Microsoft.EntityFrameworkCore;

namespace Agrio.Todo.Service.Features.Tasks.GetTask;

public sealed class GetTaskCommandHandler(ServiceDbContext db) : ICommandHandler<GetTaskCommand, GetTaskResult> {
	public async Task<GetTaskResult> ExecuteAsync(GetTaskCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var task = await db.Tasks
			.AsNoTracking()
			.Where(t => t.Id == command.Id)
			.FirstOrDefaultAsync(ct) ?? throw new Exception("Task not found");
		//TODO: Standardize exceptions

		var response = mapper.FromEntity(task);

		return response;
	}
}
