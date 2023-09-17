using Agrio.PIM.Service.Features.Entities;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;


namespace Agrio.PIM.Service.Features.Products.UpdateProduct;

public class Mapper : Mapper<UpdateProductCommand, UpdateProductResult, ProductEntity>
{
	public override ProductEntity UpdateEntity(UpdateProductCommand r, ProductEntity e)
	{
		e.IsOutOfStock = r.IsOutOfStock;
		e.Title = r.Title;
		e.Quantity = r.Quantity;
		return e;
	}
	public override UpdateProductResult FromEntity(ProductEntity e) => new(
				Id: e.Id,
				IsOutOfStock: e.IsOutOfStock,
				Title: e.Title,
				Quantity: e.Quantity
		);
}