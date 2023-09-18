using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.UpdateProduct;

public class UpdateProductEndpointBase<TMapper> :
	Endpoint<Request, Results<Ok<Response>, NotFound, ProblemDetails>, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Put("/products/{id}");
		AllowAnonymous();
	}
}
