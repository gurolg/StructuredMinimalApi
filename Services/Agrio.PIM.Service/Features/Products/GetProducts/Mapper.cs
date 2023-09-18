using System.Collections.Generic;
using System.Linq;

using Agrio.PIM.Service.Features.Entities;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;

namespace Agrio.PIM.Service.Features.Products.GetProducts;

public class Mapper : Mapper<GetProductsCommand, GetProductsResult, List<ProductEntity>> {
	public override GetProductsResult FromEntity(List<ProductEntity> e) {
		return new GetProductsResult {
			TotalCount = e.Count,
			Items = e.Select(i => new ProductListItem(
				i.Id,
				i.IsOutOfStock,
				i.Title,
				i.Quantity
			)).ToList()
		};
	}
}
