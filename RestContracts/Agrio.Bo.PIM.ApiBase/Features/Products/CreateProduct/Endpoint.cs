using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.PIM.ApiBase.Features.Products.CreateProduct;

public class CreateProductEndpointBase<TMapper> :
	Endpoint<Request, Results<Created<Response>, BadRequest, ProblemDetails>, TMapper> where TMapper : IMapper {
	public override void Configure() {
		Post("/products");
		AllowAnonymous();
	}
}
