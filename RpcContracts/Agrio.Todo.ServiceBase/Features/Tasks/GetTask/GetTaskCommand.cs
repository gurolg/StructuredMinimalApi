namespace Agrio.Todo.ServiceBase.Features.Tasks.GetTask;

public class GetTaskCommand : ICommand<GetTaskResult>
{
	public Guid Id { get; set; }
}
//TODO: Add Validation


public record GetTaskResult(
		Guid Id,
		bool IsComplete = false,
		string Title = "");