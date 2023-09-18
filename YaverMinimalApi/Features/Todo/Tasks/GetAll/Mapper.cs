using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

using TaskListItem = Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks.TaskListItem;

namespace YaverMinimalApi.Features.Todo.Tasks.GetAll;

public class Mapper : Mapper<Request, TaskListResponse, GetTasksResult> {
	public override TaskListResponse FromEntity(GetTasksResult e) {
		return new TaskListResponse(
			e.TotalCount,
			e.Items.Select(i => new TaskListItem(
				i.Id,
				i.IsComplete,
				i.Title
			)).ToList()
		);
	}
}
