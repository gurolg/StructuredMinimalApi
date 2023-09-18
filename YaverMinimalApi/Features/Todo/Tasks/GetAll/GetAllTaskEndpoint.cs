using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.Todo.Tasks.GetAll;

public class GetAllTaskEndpoint : GetAllTaskEndpointBase<Mapper> {
	public override async Task<Results<Ok<TaskListResponse>, ProblemDetails>> ExecuteAsync(Request req,
		CancellationToken ct) {
		var result = await new GetTasksCommand {
				Term = req.Term,
				AcceptLanguage = req.AcceptLanguage,
				Limit = req.Limit,
				Offset = req.Offset,
				Sort = req.Sort
			}
			.RemoteExecuteAsync();
		//TODO: Pass CancellationToken


		var response = Map.FromEntity(result);
		return TypedResults.Ok(response);
	}
}
