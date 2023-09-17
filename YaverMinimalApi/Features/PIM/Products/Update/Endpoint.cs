using Agrio.Bo.PIM.ApiBase.Features.Products.UpdateProduct;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Features.Products.Update;

public class UpdateProductEndpoint(ApiDbContext db) : UpdateProductEndpointBase<Mapper>
{
    private readonly ApiDbContext _db = db;

    public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        var product = await _db.Products.Where(x => x.Id == req.Id).FirstOrDefaultAsync();

        if (product == null) return TypedResults.NotFound();

        product = Map.UpdateEntity(req, product);
        _db.Products.Update(product);
        await _db.SaveChangesAsync(ct);

        var response = Map.FromEntity(product);
        return TypedResults.Ok(response);
    }
}