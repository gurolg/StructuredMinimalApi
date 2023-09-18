using Agrio.PIM.Service.Features.Entities;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

namespace Agrio.PIM.Service.Features.Products.CreateProduct;

public class Mapper : Mapper<CreateProductCommand, CreateProductResult, ProductEntity> {
	public override CreateProductResult FromEntity(ProductEntity entity) {
		return new CreateProductResult {
			Id = entity.Id, IsOutOfStock = entity.IsOutOfStock, Title = entity.Title, Quantity = entity.Quantity
		};
	}

	public override ProductEntity ToEntity(CreateProductCommand command) {
		return new ProductEntity { Id = Guid.NewGuid(), IsOutOfStock = false, Title = command.Title, Quantity = 0 };
	}
}
