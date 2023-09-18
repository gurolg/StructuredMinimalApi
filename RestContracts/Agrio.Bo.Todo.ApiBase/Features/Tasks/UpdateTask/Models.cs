using FluentValidation;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;

public class Request {
	[BindFrom("Accept-Language")]
	// [FromHeader]
	public string AcceptLanguage { get; set; }

	// [From]
	[BindFrom("id")] public Guid Id { get; set; }

	[BindFrom("isComplete")] public bool IsComplete { get; set; }

	[BindFrom("title")] public string Title { get; set; }
}

public class Validator : Validator<Request> {
	public Validator() {
		RuleFor(x => x.AcceptLanguage).NotEmpty();
		RuleFor(x => x.Id).NotEmpty();
	}
}

public record Response(
	Guid Id,
	bool IsComplete = false,
	string Title = "");
