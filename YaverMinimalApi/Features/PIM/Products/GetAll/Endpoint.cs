using System.Text.Json;
using Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Products.GetAll;

public class GetAllProductEndpoint(ApiDbContext db) : GetAllProductEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Ok<ProductListResponse>, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        Console.WriteLine(JsonSerializer.Serialize(req));
        var products = await _db.Products
            .AsNoTracking()
            .Where(t => string.IsNullOrEmpty(req.Term) || t.Title.Contains(req.Term))
            .ToListAsync();


        var response = Map.FromEntity(products);
        return TypedResults.Ok(response);
    }
}