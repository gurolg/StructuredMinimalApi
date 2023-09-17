using Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;
using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.Todo.Tasks.Create;

public class CreateTaskEndpoint() : CreateTaskEndpointBase<Mapper>
{

    public override async Task<Results<Created<Response>, BadRequest, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        var result = await new CreateTaskCommand
        {
            Title = req.Title
        }.RemoteExecuteAsync();


        var response = Map.FromEntity(result);
        return TypedResults.Created("", response);
    }
}