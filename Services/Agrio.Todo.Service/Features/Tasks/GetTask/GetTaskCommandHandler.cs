using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;

namespace Agrio.Todo.Service.Features.Tasks.GetTask;

public sealed class GetTaskCommandHandler(ServiceDbContext db) : ICommandHandler<GetTaskCommand, GetTaskResult> {
	public async Task<GetTaskResult> ExecuteAsync(GetTaskCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var task = await TaskQueries.GetTaskByIdAsync(db, command.Id, ct)
		?? throw new Exception("Task not found");

		//TODO: Standardize exceptions

		var response = mapper.FromEntity(task);

		return response;
	}
}
