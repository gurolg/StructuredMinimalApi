using System;

namespace TaskManager.ApiBase.Todos.Dtos;

public record TodoDto(
			Guid Id,
			bool IsComplete = false,
			string Title = "");
