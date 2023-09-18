using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;

public class UpdateTaskEndpointBase<TMapper> :
	Endpoint<Request, Results<Ok<Response>, NotFound, ProblemDetails>, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Put("/Tasks/{id}");
		AllowAnonymous();
	}
}
