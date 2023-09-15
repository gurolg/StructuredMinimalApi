using Microsoft.AspNetCore.Http.HttpResults;
using TaskManager.ApiBase.Todos.Dtos;
using TaskManager.ApiBase.Todos.Endpoints;
using YaverMinimalApi.Data;
using YaverMinimalApi.Modules.Todos.Entities;
using YaverMinimalApi.Modules.Todos.Mappers;

namespace YaverMinimalApi.Modules.Todos.Endpoints;

public class GetTodoEndpoint : GetTodoEndpointBase
{
	private readonly ApiDbContext _db;

	public GetTodoEndpoint(ApiDbContext db)
	{
		_db = db;
	}

	public override async Task<Results<Ok<TodoDto>, NotFound>> HandleAsync(
			string acceptLanguage,
			Guid id)
	{
		return await _db.Todos.FindAsync(id) switch
		{
			ToDoEntity todo => TypedResults.Ok(todo.AsTodoItem()),
			_ => TypedResults.NotFound()
		};
	}
}
