using Microsoft.AspNetCore.Http.HttpResults;
using ProductManager.ApiBase.Products.Dtos;
using ProductManager.ApiBase.Products.Endpoints;

using YaverMinimalApi.Data;
using YaverMinimalApi.Modules.Products.Mappers;

namespace YaverMinimalApi.Modules.Products.Endpoints;

public class CreateProductEndpoint : CreateProductEndpointBase
{
	private readonly ApiDbContext _db;

	public CreateProductEndpoint(ApiDbContext db)
	{
		_db = db;
	}


	public override async Task<Created<ProductDto>> HandleAsync(
			string acceptLanguage,
			ProductCreateDto payload,
			CancellationToken cancellationToken)
	{
		var Product = payload.AsProductEntity();

		_db.Products.Add(Product);
		await _db.SaveChangesAsync();

		return TypedResults.Created($"/Products/{Product.Id}", Product.AsProductItem());
	}
}
