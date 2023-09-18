using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

using Microsoft.EntityFrameworkCore;

namespace Agrio.Todo.Service.Features.Tasks.UpdateTask;

public sealed class UpdateTaskCommandHandler
	(ServiceDbContext db) : ICommandHandler<UpdateTaskCommand, UpdateTaskResult> {
	public async Task<UpdateTaskResult> ExecuteAsync(UpdateTaskCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var task = await db.Tasks
			.AsNoTracking()
			.Where(t => t.Id == command.Id)
			.FirstOrDefaultAsync(ct) ?? throw new Exception("Task not found");
		//TODO: Standardize exceptions


		task = mapper.UpdateEntity(command, task);
		db.Tasks.Update(task);
		await db.SaveChangesAsync(ct);

		var response = mapper.FromEntity(task);

		return response;
	}
}
