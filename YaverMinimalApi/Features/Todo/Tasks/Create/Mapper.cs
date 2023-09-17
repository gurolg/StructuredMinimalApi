using Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;
using YaverMinimalApi.Features.Todo.Entities;


namespace YaverMinimalApi.Features.Tasks.Create;

public class Mapper : Mapper<Request, Response, TaskEntity>
{
    public override TaskEntity ToEntity(Request r)
    {
        return new TaskEntity
        {
            IsComplete = false,
            Title = r.Title,
            Id = Guid.NewGuid()
        };
    }

    public override Response FromEntity(TaskEntity e)
    {
        return new Response
        {
            Id = e.Id,
            IsComplete = e.IsComplete,
            Title = e.Title
        };
    }
}