using Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;
using Microsoft.AspNetCore.Http.HttpResults;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Tasks.Create;

public class CreateTaskEndpoint(ApiDbContext db) : CreateTaskEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Created<Response>, BadRequest, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        var Task = Map.ToEntity(req);
        _db.Tasks.Add(Task);
        await _db.SaveChangesAsync(ct);

        var response = Map.FromEntity(Task);
        return TypedResults.Created("", response);
    }
}