using Agrio.Todo.Service.Data;
using Agrio.Todo.Service.Features.Tasks.CreateTask;
using Agrio.Todo.Service.Features.Tasks.GetTask;
using Agrio.Todo.Service.Features.Tasks.GetTasks;
using Agrio.Todo.Service.Features.Tasks.UpdateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Accept only HTTP/2 to allow insecure connections for development.
builder.WebHost.ConfigureKestrel(o => o.ListenLocalhost(6001, c => c.Protocols = HttpProtocols.Http2));
builder.AddHandlerServer();


builder.Services.AddDbContext<ServiceDbContext>(options => options.UseInMemoryDatabase("Todo"));

if (builder.Environment.IsDevelopment()) {
	builder.Services.AddGrpcReflection();
}

var app = builder.Build();


app.MapHandlers(h => {
	h.Register<CreateTaskCommand, CreateTaskHandler, CreateTaskResult>();
	h.Register<GetTasksCommand, GetTasksCommandHandler, GetTasksResult>();
	h.Register<GetTaskCommand, GetTaskCommandHandler, GetTaskResult>();
	h.Register<UpdateTaskCommand, UpdateTaskCommandHandler, UpdateTaskResult>();
});

using (var scope = app.Services.CreateScope()) {
	var context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();
	context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment()) {
	app.MapGrpcReflectionService();
}

app.Run();
