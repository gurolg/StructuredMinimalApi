using FluentValidation;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;

public class Request
{
    [BindFrom("Accept-Language")]
    // [FromHeader]
    public string AcceptLanguage { get; set; }

    public string Title { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.AcceptLanguage).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}

public class Response
{
    public Guid Id { get; set; }
    public bool IsComplete { get; set; }
    public string Title { get; set; }
}