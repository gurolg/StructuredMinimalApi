namespace YaverMinimalApi.Features.Todo.Entities;

public class TaskEntity()
{
	public Guid Id { get; init; } = Guid.NewGuid();
	public bool IsComplete { get; set; } = false;
	public string Title { get; set; } = string.Empty;
}