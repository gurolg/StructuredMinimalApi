using System.Collections.Generic;
using System.Linq;
using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;


namespace Agrio.Todo.Service.Features.Tasks.GetTasks;

public class Mapper : Mapper<GetTasksCommand, GetTasksResult, List<TaskEntity>>
{
	public override GetTasksResult FromEntity(List<TaskEntity> e) => new()
	{
		TotalCount = e.Count,
		Items = e.Select(e => new TaskListItem(
										e.Id,
										e.IsComplete,
										e.Title
		)).ToList()
	};
}