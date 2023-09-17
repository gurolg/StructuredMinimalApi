using System.Collections.Generic;

namespace Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;

public class GetTasksCommand : ICommand<GetTasksResult>
{
	public string AcceptLanguage { get; set; }
	public int? Limit { get; set; }
	public int? Offset { get; set; }
	public string Term { get; set; }
	public string Sort { get; set; }
}
//TODO: Add Validation

public class GetTasksResult
{
	public int? TotalCount { get; set; } = 0;
	public List<TaskListItem> Items { get; set; }
}

public record TaskListItem(
		Guid Id,
		bool IsComplete = false,
		string Title = "");