namespace Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;

public class CreateTaskCommand : ICommand<CreateTaskResult> {
	public string Title { get; init; }
}

//TODO: Add Validation

public class CreateTaskResult {
	public Guid Id { get; init; }
	public bool IsComplete { get; init; }
	public string Title { get; init; }
}
