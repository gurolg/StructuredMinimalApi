using System;

namespace TaskManager.ApiBase.Todos.Dtos;

public record TodoUpdateDto(
				bool IsComplete = false,
				string Title = "");