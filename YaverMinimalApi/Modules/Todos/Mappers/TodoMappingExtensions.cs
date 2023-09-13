using TaskManager.ApiBase.Todos.Dtos;
using YaverMinimalApi.Modules.Todos.Entities;

namespace YaverMinimalApi.Modules.Todos.Mappers;
public static class TodoMappingExtensions
{
	public static TodoDto AsTodoItem(this ToDoEntity todo) => new(
					Id: todo.Id,
					IsComplete: todo.IsComplete,
					Title: todo.Title);


	public static TodoListItemDto AsTodoListItem(this ToDoEntity todo) => new(
					Id: todo.Id,
					IsComplete: todo.IsComplete,
					Title: todo.Title);

	public static ToDoEntity AsTodoEntity(this TodoCreateDto todo) => new(
		Id: todo.Id,
		IsComplete: todo.IsComplete,
		Title: todo.Title
	);

}