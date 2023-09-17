using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;
using Microsoft.EntityFrameworkCore;


namespace Agrio.Todo.Service.Features.Tasks.UpdateTask;

public sealed class UpdateTaskCommandHandler(ServiceDbContext _db) : ICommandHandler<UpdateTaskCommand, UpdateTaskResult>
{
	public async Task<UpdateTaskResult> ExecuteAsync(UpdateTaskCommand command, CancellationToken ct)
	{

		var _mapper = new Mapper();

		var Task = await _db.Tasks
						.AsNoTracking()
						.Where(t => t.Id == command.Id)
						.FirstOrDefaultAsync(ct) ?? throw new Exception("Task not found");
		//TODO: Standardize exceptions


		Task = _mapper.UpdateEntity(command, Task);
		_db.Tasks.Update(Task);
		await _db.SaveChangesAsync(ct);

		var response = _mapper.FromEntity(Task);

		return response;
	}
}
