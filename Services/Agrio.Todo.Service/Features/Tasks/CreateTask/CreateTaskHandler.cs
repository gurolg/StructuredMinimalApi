using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;

namespace Agrio.Todo.Service.Features.Tasks.CreateTask;

public sealed class CreateTaskHandler(ServiceDbContext db) : ICommandHandler<CreateTaskCommand, CreateTaskResult> {
	public async Task<CreateTaskResult> ExecuteAsync(CreateTaskCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var product = mapper.ToEntity(command);
		db.Tasks.Add(product);
		await db.SaveChangesAsync(ct);

		var response = mapper.FromEntity(product);

		return response;
	}
}
