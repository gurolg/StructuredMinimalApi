using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManager.ApiBase.Todos.Dtos;
using TaskManager.ApiBase.Todos.Endpoints;
using YaverMinimalApi.Data;

namespace YaverMinimalApi.Modules.Todos.Endpoints;

public class UpdateTodoEndpoint : UpdateTodoEndpointBase, IYaverEndpoint
{
	private readonly ApiDbContext _db;

	public UpdateTodoEndpoint(ApiDbContext db)
	{
		_db = db;
	}

	public override async Task<Results<Ok, NotFound, BadRequest>> HandleAsync(
			string acceptLanguage,
			Guid id,
			TodoUpdateDto payload,
			CancellationToken cancellationToken)
	{
		//TODO: try ExecuteUpdateAsync on rdbms
		// var rowsAffected = await _db.Todos
		// 		.Where(t => t.Id == id)
		// 		.ExecuteUpdateAsync(updates => updates
		// 						.SetProperty(
		// 								t => t.IsComplete,
		// 								payload.IsComplete)
		// 						.SetProperty(t => t.Title, payload.Title));


		var todo = _db.Todos.AsNoTracking().First(b => b.Id == id) ?? throw new InvalidOperationException();
		if (todo == null)
		{
			return TypedResults.NotFound();
		}

		var updatedRecord = todo with
		{
			Title = payload.Title,
			IsComplete = payload.IsComplete
		};

		_db.Update(updatedRecord);


		var rowsAffected = _db.SaveChanges();


		return rowsAffected == 0 ? TypedResults.NotFound() : TypedResults.Ok();

	}
}
