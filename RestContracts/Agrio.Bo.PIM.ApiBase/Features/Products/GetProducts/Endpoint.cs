using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;

public class GetAllProductEndpointBase<TMapper> :
	Endpoint<Request, Results<Ok<ProductListResponse>, ProblemDetails>, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Get("/products");
		AllowAnonymous();
	}
}
