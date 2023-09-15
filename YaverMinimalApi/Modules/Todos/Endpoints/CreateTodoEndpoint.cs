using Microsoft.AspNetCore.Http.HttpResults;
using TaskManager.ApiBase.Todos.Dtos;
using TaskManager.ApiBase.Todos.Endpoints;
using YaverMinimalApi.Data;
using YaverMinimalApi.Modules.Todos.Mappers;

namespace YaverMinimalApi.Modules.Todos.Endpoints;

public class CreateTodoEndpoint : CreateTodoEndpointBase
{
	private readonly ApiDbContext _db;

	public CreateTodoEndpoint(ApiDbContext db)
	{
		_db = db;
	}


	public override async Task<Created<TodoDto>> HandleAsync(
			string acceptLanguage,
			TodoCreateDto payload,
			CancellationToken cancellationToken)
	{
		var todo = payload.AsTodoEntity();

		_db.Todos.Add(todo);
		await _db.SaveChangesAsync();

		return TypedResults.Created($"/todos/{todo.Id}", todo.AsTodoItem());
	}
}
