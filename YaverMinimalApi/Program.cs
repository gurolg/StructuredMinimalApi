using Microsoft.EntityFrameworkCore;
using YaverMinimalApi.Data;
using YaverMinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpoints();

builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("ToDoList"));

// var connectionString = builder.Configuration.GetConnectionString("Todos") ?? "Data Source=.db/Todos.db";
// builder.Services.AddSqlite<TodoDbContext>(connectionString);

var app = builder.Build();
app.MapEndpoints();

using (var Scope = app.Services.CreateScope())
{
	var context = Scope.ServiceProvider.GetRequiredService<ApiDbContext>();
	context.Database.EnsureCreated();
}

app.Run();
