using Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Tasks.Update;

public class UpdateTaskEndpoint(ApiDbContext db) : UpdateTaskEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        var Task = await _db.Tasks.Where(x => x.Id == req.Id).FirstOrDefaultAsync();

        if (Task == null) return TypedResults.NotFound();

        Task = Map.UpdateEntity(req, Task);
        _db.Tasks.Update(Task);
        await _db.SaveChangesAsync(ct);

        var response = Map.FromEntity(Task);
        return TypedResults.Ok(response);
    }
}