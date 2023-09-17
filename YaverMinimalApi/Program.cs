global using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication();


builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("ToDoList"));


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
using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    context.Database.EnsureCreated();
}

app.Run();