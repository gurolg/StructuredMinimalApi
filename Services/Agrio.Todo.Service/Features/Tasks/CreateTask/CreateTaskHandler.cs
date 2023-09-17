using System.Threading;
using System.Threading.Tasks;

using Agrio.Todo.Service.Data;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;


namespace Agrio.Todo.Service.Features.Tasks.CreateTask;

public sealed class CreateTaskHandler(ServiceDbContext _db) : ICommandHandler<CreateTaskCommand, CreateTaskResult>
{
    public async Task<CreateTaskResult> ExecuteAsync(CreateTaskCommand command, CancellationToken ct)
    {
        var _mapper = new Mapper();

        var product = _mapper.ToEntity(command);
        _db.Tasks.Add(product);
        await _db.SaveChangesAsync(ct);

        var response = _mapper.FromEntity(product);

        return response;
    }
}
