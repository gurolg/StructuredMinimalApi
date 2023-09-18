using Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

namespace YaverMinimalApi.Features.Todo.Tasks.Update;

public class Mapper : Mapper<Request, Response, UpdateTaskResult> {
	public override Response FromEntity(UpdateTaskResult e) {
		return new Response(
			e.Id,
			e.IsComplete,
			e.Title
		);
	}
}
