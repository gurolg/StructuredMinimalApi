using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;
using Microsoft.EntityFrameworkCore;


namespace Agrio.Todo.Service.Features.Tasks.GetTask;

public sealed class GetTaskCommandHandler(ServiceDbContext _db) : ICommandHandler<GetTaskCommand, GetTaskResult>
{
    public async Task<GetTaskResult> ExecuteAsync(GetTaskCommand command, CancellationToken ct)
    {

        var _mapper = new Mapper();

        var Task = await _db.Tasks
                .AsNoTracking()
                .Where(t => t.Id == command.Id)
                .FirstOrDefaultAsync(ct) ?? throw new Exception("Task not found");
        //TODO: Standardize exceptions

        var response = _mapper.FromEntity(Task);

        return response;
    }
}
