using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;
using YaverMinimalApi.Features.Todo.Entities;


namespace YaverMinimalApi.Features.Tasks.Get;

public class Mapper : Mapper<Request, Response, TaskEntity>
{
    public override Response FromEntity(TaskEntity e)
    {
        return new Response(
            e.Id,
            e.IsComplete,
            e.Title
        );
    }
}