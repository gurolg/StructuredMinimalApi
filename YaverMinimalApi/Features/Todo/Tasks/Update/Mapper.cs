using Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;
using YaverMinimalApi.Features.Todo.Entities;


namespace YaverMinimalApi.Features.Tasks.Update;

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

    public override TaskEntity UpdateEntity(Request r, TaskEntity e)
    {
        e.IsComplete = r.IsComplete;
        e.Title = r.Title;
        return e;
    }
}