using Agrio.Bo.PIM.ApiBase.Features.Products.CreateProduct;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.PIM.Products.Create;

public class CreateProductEndpoint : CreateProductEndpointBase<Mapper> {
	public override async Task<Results<Created<Response>, BadRequest, ProblemDetails>> ExecuteAsync(
		Request req,
		CancellationToken ct) {
		var result = await new CreateProductCommand { Title = req.Title }.RemoteExecuteAsync();


		var response = Map.FromEntity(result);
		return TypedResults.Created("", response);
	}
}
