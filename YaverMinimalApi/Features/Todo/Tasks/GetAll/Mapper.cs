using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;
using YaverMinimalApi.Features.Todo.Entities;

namespace YaverMinimalApi.Features.Tasks.GetAll;

public class Mapper : Mapper<Request, TaskListResponse, List<TaskEntity>>
{
    public override TaskListResponse FromEntity(List<TaskEntity> e)
    {
        return new TaskListResponse(
            e.Count,
            e.Select(e => new TaskListItem(
                e.Id,
                e.IsComplete,
                e.Title
            )).ToList()
        );
    }
}