using System;

namespace TaskManager.ApiBase.Todos.Dtos;

public record TodoCreateDto(
				Guid Id,
				bool IsComplete = false,
				string Title = "");