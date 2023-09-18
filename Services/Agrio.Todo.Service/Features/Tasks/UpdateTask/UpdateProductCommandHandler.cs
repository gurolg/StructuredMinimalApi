using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

namespace Agrio.Todo.Service.Features.Tasks.UpdateTask;

public sealed class UpdateTaskCommandHandler
	(ServiceDbContext db) : ICommandHandler<UpdateTaskCommand, UpdateTaskResult> {
	public async Task<UpdateTaskResult> ExecuteAsync(UpdateTaskCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var task = await TaskQueries.GetTaskByIdAsync(db, command.Id, ct)
		?? throw new Exception("Task not found");

		//TODO: Standardize exceptions


		task = mapper.UpdateEntity(command, task);
		db.Tasks.Update(task);
		await db.SaveChangesAsync(ct);

		var response = mapper.FromEntity(task);

		return response;
	}
}
