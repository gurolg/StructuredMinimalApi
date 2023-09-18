using System.Collections.Generic;
using System.Linq;

using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

namespace Agrio.Todo.Service.Features.Tasks.GetTasks;

public class Mapper : Mapper<GetTasksCommand, GetTasksResult, List<TaskEntity>> {
	public override GetTasksResult FromEntity(List<TaskEntity> e) {
		return new GetTasksResult {
			TotalCount = e.Count,
			Items = e.Select(i => new TaskListItem(
				i.Id,
				i.IsComplete,
				i.Title
			)).ToList()
		};
	}
}
