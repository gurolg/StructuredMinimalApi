using Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;

using ProductListItem = Agrio.Bo.PIM.ApiBase.Features.Products.GetProducts.ProductListItem;

namespace YaverMinimalApi.Features.PIM.Products.GetAll;

public class Mapper : Mapper<Request, ProductListResponse, GetProductsResult> {
	public override ProductListResponse FromEntity(GetProductsResult e) {
		return new ProductListResponse(
			e.TotalCount,
			e.Items.Select(i => new ProductListItem(
				i.Id,
				i.IsOutOfStock,
				i.Title,
				i.Quantity
			)).ToList()
		);
	}
}
