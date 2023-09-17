using Agrio.Bo.PIM.ApiBase.Features.Products.UpdateProduct;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;
using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.PIM.Products.Update;

public class UpdateProductEndpoint() : UpdateProductEndpointBase<Mapper>
{


    public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {


        var result = await new UpdateProductCommand
        {
            Id = req.Id,
            Title = req.Title,
            IsOutOfStock = req.IsOutOfStock,
            Quantity = req.Quantity
        }
              .RemoteExecuteAsync();
        //TODO: Pass CancellationToken


        var response = Map.FromEntity(result);
        return TypedResults.Ok(response);
    }
}