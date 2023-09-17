namespace Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

public class UpdateTaskCommand : ICommand<UpdateTaskResult>
{
	public Guid Id { get; set; }
	public bool IsComplete { get; set; }
	public string Title { get; set; }
}
//TODO: Add Validation


public record UpdateTaskResult(
		Guid Id,
		bool IsComplete = false,
		string Title = "");