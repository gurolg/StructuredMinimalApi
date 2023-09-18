using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;

namespace Agrio.Todo.Service.Features.Tasks.GetTask;

public class Mapper : Mapper<GetTaskCommand, GetTaskResult, TaskEntity> {
	public override GetTaskResult FromEntity(TaskEntity e) {
		return new GetTaskResult(
			e.Id,
			e.IsComplete,
			e.Title
		);
	}
}
