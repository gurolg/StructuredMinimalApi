using Agrio.PIM.Service.Features.Entities;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;


namespace Agrio.PIM.Service.Features.Products.GetProduct;

public class Mapper : Mapper<GetProductCommand, GetProductResult, ProductEntity>
{
	public override GetProductResult FromEntity(ProductEntity e) => new(
					Id: e.Id,
					IsOutOfStock: e.IsOutOfStock,
					Title: e.Title,
					Quantity: e.Quantity
			);
}