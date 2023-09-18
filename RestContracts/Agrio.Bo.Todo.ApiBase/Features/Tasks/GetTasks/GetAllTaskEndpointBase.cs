using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;

public class GetAllTaskEndpointBase<TMapper> :
	Endpoint<Request, Results<Ok<TaskListResponse>, ProblemDetails>, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Get("/Tasks");
		AllowAnonymous();
	}
}
