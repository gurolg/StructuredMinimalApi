using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.Todo.Tasks.Get;

public class GetTaskEndpoint : GetTaskEndpointBase<Mapper> {
	public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
		Request req,
		CancellationToken ct) {
		var result = await new GetTaskCommand { Id = req.Id }
			.RemoteExecuteAsync();
		//TODO: Pass CancellationToken


		var response = Map.FromEntity(result);
		return TypedResults.Ok(response);
	}
}
