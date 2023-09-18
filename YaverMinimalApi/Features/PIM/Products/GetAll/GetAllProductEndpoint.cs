using Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;

using Microsoft.AspNetCore.Http.HttpResults;

namespace YaverMinimalApi.Features.PIM.Products.GetAll;

public class GetAllProductEndpoint : GetAllProductEndpointBase<Mapper> {
	public override async Task<Results<Ok<ProductListResponse>, ProblemDetails>> ExecuteAsync(Request req,
		CancellationToken ct) {
		var result = await new GetProductsCommand {
				Term = req.Term,
				AcceptLanguage = req.AcceptLanguage,
				Limit = req.Limit,
				Offset = req.Offset,
				Sort = req.Sort
			}
			.RemoteExecuteAsync();
		//TODO: Pass CancellationToken


		var response = Map.FromEntity(result);
		return TypedResults.Ok(response);
	}
}
