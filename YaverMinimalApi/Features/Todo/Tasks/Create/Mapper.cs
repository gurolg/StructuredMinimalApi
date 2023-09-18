using Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;

namespace YaverMinimalApi.Features.Todo.Tasks.Create;

public class Mapper : Mapper<Request, Response, CreateTaskResult> {
	public override Response FromEntity(CreateTaskResult e) {
		return new Response { Id = e.Id, IsComplete = e.IsComplete, Title = e.Title };
	}
}
