using System.Text.Json;
using Agrio.Bo.PIM.ApiBase.Features.Products.GetProduct;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Products.Get;

public class GetProductEndpoint(ApiDbContext db) : GetProductEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        Console.WriteLine(JsonSerializer.Serialize(req));
        var product = await _db.Products.Where(x => x.Id == req.Id).FirstOrDefaultAsync();

        if (product == null) return TypedResults.NotFound();

        var response = Map.FromEntity(product);
        return TypedResults.Ok(response);
    }
}