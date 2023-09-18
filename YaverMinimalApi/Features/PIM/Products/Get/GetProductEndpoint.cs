using Agrio.Bo.PIM.ApiBase.Features.Products.GetProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.PIM.Products.Get;

public class GetProductEndpoint : GetProductEndpointBase<Mapper> {
	public override async Task<Results<Ok<Response>, NotFound, ProblemDetails>> ExecuteAsync(
		Request req,
		CancellationToken ct) {
		var result = await new GetProductCommand { Id = req.Id }
			.RemoteExecuteAsync();
		//TODO: Pass CancellationToken


		var response = Map.FromEntity(result);
		return TypedResults.Ok(response);
	}
}
