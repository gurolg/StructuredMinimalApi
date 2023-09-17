using System.Collections.Generic;
using System.Linq;
using Agrio.PIM.Service.Features.Entities;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;


namespace Agrio.PIM.Service.Features.Products.GetProducts;

public class Mapper : Mapper<GetProductsCommand, GetProductsResult, List<ProductEntity>>
{
	public override GetProductsResult FromEntity(List<ProductEntity> e) => new()
	{
		TotalCount = e.Count,
		Items = e.Select(e => new ProductListItem(
						e.Id,
						e.IsOutOfStock,
						e.Title,
						e.Quantity
		)).ToList()
	};
}