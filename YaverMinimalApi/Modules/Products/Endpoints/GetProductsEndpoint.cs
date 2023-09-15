using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductManager.ApiBase.Products.Dtos;
using ProductManager.ApiBase.Products.Endpoints;
using YaverMinimalApi.Data;
using YaverMinimalApi.Modules.Products.Mappers;

namespace YaverMinimalApi.Modules.Products.Endpoints;

public class GetProductsEndpoint : GetProductsEndpointBase
{
	private readonly ApiDbContext _db;

	public GetProductsEndpoint(ApiDbContext db)
	{
		_db = db;
	}
	public override async Task<Results<Ok<ProductListDto>, NotFound>> HandleAsync(
							string acceptLanguage,
							int? limit,
							int? offset,
							string term,
							string sort)
	{
		var Products = await _db.Products
						.Where(t => string.IsNullOrEmpty(term) || t.Title.Contains(term))
						.Select(t => t.AsProductListItem())
						.AsNoTracking()
						.ToListAsync();

		var result = new ProductListDto(
			TotalCount: Products.Count,
			Items: Products);

		return TypedResults.Ok(result);
	}
}
