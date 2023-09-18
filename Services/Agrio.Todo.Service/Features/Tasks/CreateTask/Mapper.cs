using Agrio.Todo.Service.Features.Entities;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;

namespace Agrio.Todo.Service.Features.Tasks.CreateTask;

public class Mapper : Mapper<CreateTaskCommand, CreateTaskResult, TaskEntity> {
	public override CreateTaskResult FromEntity(TaskEntity entity) {
		return new CreateTaskResult { Id = entity.Id, IsComplete = entity.IsComplete, Title = entity.Title };
	}

	public override TaskEntity ToEntity(CreateTaskCommand command) {
		return new TaskEntity { Id = Guid.NewGuid(), IsComplete = false, Title = command.Title };
	}
}
