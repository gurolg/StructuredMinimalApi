using ProductManager.ApiBase.Products.Dtos;
using YaverMinimalApi.Modules.Products.Entities;

namespace YaverMinimalApi.Modules.Products.Mappers;
public static class ProductMappingExtensions
{
	public static ProductDto AsProductItem(this ProductEntity Product) => new(
					Id: Product.Id,
					IsOutOfStock: Product.IsOutOfStock,
					Title: Product.Title);


	public static ProductListItemDto AsProductListItem(this ProductEntity Product) => new(
					Id: Product.Id,
					IsOutOfStock: Product.IsOutOfStock,
					Title: Product.Title);

	public static ProductEntity AsProductEntity(this ProductCreateDto Product) => new(
		Id: Product.Id,
		IsOutOfStock: Product.IsOutOfStock,
		Title: Product.Title
	);

}