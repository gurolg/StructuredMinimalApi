using Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.Todo.Tasks.Update;

public class UpdateTaskEndpoint : UpdateTaskEndpointBase<Mapper> {
	public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
		Request req,
		CancellationToken ct) {
		var result = await new UpdateTaskCommand { Id = req.Id, Title = req.Title, IsComplete = req.IsComplete }
			.RemoteExecuteAsync();
		//TODO: Pass CancellationToken


		var response = Map.FromEntity(result);
		return TypedResults.Ok(response);
	}
}
