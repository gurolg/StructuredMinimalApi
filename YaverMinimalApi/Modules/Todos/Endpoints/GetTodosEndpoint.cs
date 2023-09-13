using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManager.ApiBase.Todos.Dtos;
using TaskManager.ApiBase.Todos.Endpoints;
using YaverMinimalApi.Data;
using YaverMinimalApi.Modules.Todos.Mappers;

namespace YaverMinimalApi.Modules.Todos.Endpoints;

public class GetTodosEndpoint : GetTodosEndpointBase, IYaverEndpoint
{
	private readonly ApiDbContext _db;

	public GetTodosEndpoint(ApiDbContext db)
	{
		_db = db;
	}
	public override async Task<Results<Ok<TodoListDto>, NotFound>> HandleAsync(
							string acceptLanguage,
							int? limit,
							int? offset,
							string term,
							string sort)
	{
		var todos = await _db.Todos
						.Where(t => string.IsNullOrEmpty(term) || t.Title.Contains(term))
						.Select(t => t.AsTodoListItem())
						.AsNoTracking()
						.ToListAsync();

		var result = new TodoListDto(
			TotalCount: todos.Count,
			Items: todos);

		return TypedResults.Ok(result);
	}
}
