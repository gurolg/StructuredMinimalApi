global using FastEndpoints;
using Agrio.Bo.Todo.ApiBase.Features.Tasks.CreateTask;
using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTask;
using Agrio.Bo.Todo.ApiBase.Features.Tasks.GetTasks;
using Agrio.Bo.Todo.ApiBase.Features.Tasks.UpdateTask;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication();

var app = builder.Build();

app.UseAuthorization();
// app.UseAuthentication();

app.UseFastEndpoints(c =>
{
    c.Serializer.Options.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;

    c.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
    {
        return new Microsoft.AspNetCore.Mvc.ValidationProblemDetails(
            failures.GroupBy(f => f.PropertyName)
                    .ToDictionary(
                        keySelector: e => e.Key,
                        elementSelector: e => e.Select(m => m.ErrorMessage).ToArray()))
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred.",
            Status = statusCode,
            Instance = ctx.Request.Path,
            Extensions = { { "traceId", ctx.TraceIdentifier } }
        };
    };
});

app.MapRemote("http://localhost:6000", c =>
{
    c.Register<CreateProductCommand, CreateProductResult>();
    c.Register<GetProductsCommand, GetProductsResult>();
    c.Register<GetProductCommand, GetProductResult>();
    c.Register<UpdateProductCommand, UpdateProductResult>();
});

app.MapRemote("http://localhost:6001", c =>
{
    c.Register<CreateTaskCommand, CreateTaskResult>();
    c.Register<GetTasksCommand, GetTasksResult>();
    c.Register<GetTaskCommand, GetTaskResult>();
    c.Register<UpdateTaskCommand, UpdateTaskResult>();
});

app.Run();