using FluentValidation;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;

public class Request
{
    // [FromHeader]
    [FromHeader("Accept-Language")] public string AcceptLanguage { get; set; }

    // [From]
    [BindFrom("id")] public Guid Id { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public record Response(
    Guid Id,
    bool IsComplete = false,
    string Title = "");