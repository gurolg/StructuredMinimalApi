using System.Collections.Generic;

namespace Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

public class GetTasksCommand : ICommand<GetTasksResult> {
	public string AcceptLanguage { get; init; }
	public int? Limit { get; init; }
	public int? Offset { get; init; }
	public string Term { get; init; }
	public string Sort { get; init; }
}
//TODO: Add Validation

public class GetTasksResult {
	public int? TotalCount { get; init; } = 0;
	public List<TaskListItem> Items { get; init; }
}

public record TaskListItem(
	Guid Id,
	bool IsComplete = false,
	string Title = "");
