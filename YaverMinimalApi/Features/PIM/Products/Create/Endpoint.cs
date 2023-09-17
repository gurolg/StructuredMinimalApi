using Agrio.Bo.PIM.ApiBase.Features.Products.CreateProduct;
using Microsoft.AspNetCore.Http.HttpResults;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Products.Create;

public class CreateProductEndpoint(ApiDbContext db) : CreateProductEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Created<Response>, BadRequest, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        var product = Map.ToEntity(req);
        _db.Products.Add(product);
        await _db.SaveChangesAsync(ct);

        var response = Map.FromEntity(product);
        return TypedResults.Created("", response);
    }
}