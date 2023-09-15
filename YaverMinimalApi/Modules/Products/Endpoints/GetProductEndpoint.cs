using Microsoft.AspNetCore.Http.HttpResults;
using ProductManager.ApiBase.Products.Dtos;
using ProductManager.ApiBase.Products.Endpoints;

using YaverMinimalApi.Data;
using YaverMinimalApi.Modules.Products.Entities;
using YaverMinimalApi.Modules.Products.Mappers;

namespace YaverMinimalApi.Modules.Products.Endpoints;

public class GetProductEndpoint : GetProductEndpointBase
{
	private readonly ApiDbContext _db;

	public GetProductEndpoint(ApiDbContext db)
	{
		_db = db;
	}

	public override async Task<Results<Ok<ProductDto>, NotFound>> HandleAsync(
			string acceptLanguage,
			Guid id)
	{
		return await _db.Products.FindAsync(id) switch
		{
			ProductEntity Product => TypedResults.Ok(Product.AsProductItem()),
			_ => TypedResults.NotFound()
		};
	}
}
