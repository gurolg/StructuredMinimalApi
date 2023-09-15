using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductManager.ApiBase.Products.Dtos;
using ProductManager.ApiBase.Products.Endpoints;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Modules.Products.Endpoints;

public class UpdateProductEndpoint : UpdateProductEndpointBase
{
	private readonly ApiDbContext _db;

	public UpdateProductEndpoint(ApiDbContext db)
	{
		_db = db;
	}

	public override async Task<Results<Ok, NotFound, BadRequest>> HandleAsync(
			string acceptLanguage,
			Guid id,
			ProductUpdateDto payload,
			CancellationToken cancellationToken)
	{
		//Product: try ExecuteUpdateAsync on rdbms
		// var rowsAffected = await _db.Products
		// 		.Where(t => t.Id == id)
		// 		.ExecuteUpdateAsync(updates => updates
		// 						.SetProperty(
		// 								t => t.IsComplete,
		// 								payload.IsComplete)
		// 						.SetProperty(t => t.Title, payload.Title));


		var Product = _db.Products.AsNoTracking().First(b => b.Id == id) ?? throw new InvalidOperationException();
		if (Product == null)
		{
			return TypedResults.NotFound();
		}

		var updatedRecord = Product with
		{
			Title = payload.Title,
			IsOutOfStock = payload.IsOutOfStock
		};

		_db.Update(updatedRecord);


		var rowsAffected = _db.SaveChanges();


		return rowsAffected == 0 ? TypedResults.NotFound() : TypedResults.Ok();

	}
}
