using System.Text.Json;
using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Tasks.Get;

public class GetTaskEndpoint(ApiDbContext db) : GetTaskEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        Console.WriteLine(JsonSerializer.Serialize(req));
        var Task = await _db.Tasks.Where(x => x.Id == req.Id).FirstOrDefaultAsync();

        if (Task == null) return TypedResults.NotFound();

        var response = Map.FromEntity(Task);
        return TypedResults.Ok(response);
    }
}