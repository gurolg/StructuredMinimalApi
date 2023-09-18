using Agrio.Bo.PIM.ApiBase.Features.Products.UpdateProduct;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;

namespace YaverMinimalApi.Features.PIM.Products.Update;

public class Mapper : Mapper<Request, Response, UpdateProductResult> {
	public override Response FromEntity(UpdateProductResult e) {
		return new Response(
			e.Id,
			e.IsOutOfStock,
			e.Title,
			e.Quantity
		);
	}

	// public override ProductEntity UpdateEntity(Request r, ProductEntity e)
	// {
	//     e.IsOutOfStock = r.IsOutOfStock;
	//     e.Title = r.Title;
	//     e.Quantity = r.Quantity;
	//     return e;
	// }
}
