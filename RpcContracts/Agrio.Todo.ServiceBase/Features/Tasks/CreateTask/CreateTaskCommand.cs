namespace Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;

public class CreateTaskCommand : ICommand<CreateTaskResult>
{
    public string Title { get; set; }
}

//TODO: Add Validation


public class CreateTaskResult
{
    public Guid Id { get; set; }
    public bool IsComplete { get; set; }
    public string Title { get; set; }
}