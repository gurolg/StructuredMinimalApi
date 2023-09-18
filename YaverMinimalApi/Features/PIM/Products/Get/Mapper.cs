using Agrio.Bo.PIM.ApiBase.Features.Products.GetProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;

namespace YaverMinimalApi.Features.PIM.Products.Get;

public class Mapper : Mapper<Request, Response, GetProductResult> {
	public override Response FromEntity(GetProductResult e) {
		return new Response(
			e.Id,
			e.IsOutOfStock,
			e.Title,
			e.Quantity
		);
	}
}
