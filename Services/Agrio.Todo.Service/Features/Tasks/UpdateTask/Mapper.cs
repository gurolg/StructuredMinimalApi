
using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;


namespace Agrio.Todo.Service.Features.Tasks.UpdateTask;

public class Mapper : Mapper<UpdateTaskCommand, UpdateTaskResult, TaskEntity>
{
	public override TaskEntity UpdateEntity(UpdateTaskCommand r, TaskEntity e)
	{
		e.IsComplete = r.IsComplete;
		e.Title = r.Title;
		return e;
	}
	public override UpdateTaskResult FromEntity(TaskEntity e) => new(
				Id: e.Id,
				IsComplete: e.IsComplete,
				Title: e.Title
		);
}