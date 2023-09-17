using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

namespace YaverMinimalApi.Features.Todo.Tasks.GetAll;

public class Mapper : Mapper<Request, TaskListResponse, GetTasksResult>
{
    public override TaskListResponse FromEntity(GetTasksResult e)
    {
        return new TaskListResponse(
            e.TotalCount,
            e.Items.Select(e => new Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks.TaskListItem(
                e.Id,
                e.IsComplete,
                e.Title
            )).ToList()
        );
    }
}