
using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;


namespace Agrio.Todo.Service.Features.Tasks.GetTask;

public class Mapper : Mapper<GetTaskCommand, GetTaskResult, TaskEntity>
{
	public override GetTaskResult FromEntity(TaskEntity e) => new(
									Id: e.Id,
									IsComplete: e.IsComplete,
									Title: e.Title
					);
}