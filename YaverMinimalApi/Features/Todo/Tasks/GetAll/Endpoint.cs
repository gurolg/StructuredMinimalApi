using System.Text.Json;
using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Tasks.GetAll;

public class GetAllTaskEndpoint(ApiDbContext db) : GetAllTaskEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Ok<TaskListResponse>, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        Console.WriteLine(JsonSerializer.Serialize(req));
        var Tasks = await _db.Tasks
            .AsNoTracking()
            .Where(t => string.IsNullOrEmpty(req.Term) || t.Title.Contains(req.Term))
            .ToListAsync();


        var response = Map.FromEntity(Tasks);
        return TypedResults.Ok(response);
    }
}