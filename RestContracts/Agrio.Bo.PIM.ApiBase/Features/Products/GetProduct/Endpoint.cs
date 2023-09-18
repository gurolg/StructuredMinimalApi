using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.GetProduct;

public class GetProductEndpointBase<TMapper> :
	Endpoint<Request, Results<Ok<Response>, NotFound, ProblemDetails>, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Verbs(Http.GET);
		Routes("/products/{id}");
		AllowAnonymous();
	}
}
