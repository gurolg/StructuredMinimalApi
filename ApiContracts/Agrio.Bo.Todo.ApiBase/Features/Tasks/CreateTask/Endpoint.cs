using Microsoft.AspNetCore.Http.HttpResults;

namespace Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;

public class CreateTaskEndpointBase<TMapper> :
    Endpoint<Request, Results<Created<Response>, BadRequest, ProblemDetails>, TMapper> where TMapper : IMapper
{
    public override void Configure()
    {
        Post("/Tasks");
        AllowAnonymous();
    }
}