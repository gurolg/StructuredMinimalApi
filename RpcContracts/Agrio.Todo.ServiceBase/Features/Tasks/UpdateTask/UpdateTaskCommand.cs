namespace Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

public class UpdateTaskCommand : ICommand<UpdateTaskResult> {
	public Guid Id { get; init; }
	public bool IsComplete { get; init; }
	public string Title { get; init; }
}
//TODO: Add Validation

public record UpdateTaskResult(
	Guid Id,
	bool IsComplete = false,
	string Title = "");
