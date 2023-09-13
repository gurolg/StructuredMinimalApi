namespace YaverMinimalApi.Modules.Todos.Entities;

public record ToDoEntity(Guid Id, bool IsComplete, string Title = "");