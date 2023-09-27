
using System.Text.Json;

using Agrio.Bo.PIM.ApiBase.Models;
using Agrio.Bo.PIM.ApiBase.Tags.Products;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.PIM.Products.Create;

public class CreateProductEndpoint : CreateProductEndpointBase<Mapper> {
	public override async Task<Results<Created<CreateProductResponse>, BadRequest, ProblemDetails>> ExecuteAsync(
		CreateProductRequest req,
		CancellationToken ct) {
		Console.WriteLine(JsonSerializer.Serialize(req));
		var result = await new CreateProductCommand { Title = req.Body.Title }.RemoteExecuteAsync();

		var response = Map.FromEntity(result);
		return TypedResults.Created("", response);
	}
}
