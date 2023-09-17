using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;

namespace YaverMinimalApi.Features.Todo.Tasks.Get;

public class Mapper : Mapper<Request, Response, GetTaskResult>
{
    public override Response FromEntity(GetTaskResult e)
    {
        return new Response(
            e.Id,
            e.IsComplete,
            e.Title
        );
    }
}