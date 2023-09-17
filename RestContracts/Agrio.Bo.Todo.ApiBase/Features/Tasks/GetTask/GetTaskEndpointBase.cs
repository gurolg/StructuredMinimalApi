using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;

public class GetTaskEndpointBase<TMapper> :
    Endpoint<Request, Results<Ok<Response>, NotFound, ProblemDetails>, TMapper> where TMapper : IMapper
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/Tasks/{id}");
        AllowAnonymous();
    }
}