using System;

namespace TaskManager.ApiBase.Todos.Dtos;

public record TodoListItemDto(
	Guid Id,
	bool IsComplete = false,
	string Title = "");