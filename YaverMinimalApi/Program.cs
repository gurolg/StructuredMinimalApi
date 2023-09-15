using Microsoft.EntityFrameworkCore;
using ProductManager.ApiBase.Extensions;
using TaskManager.ApiBase.Extensions;
using YaverMinimalApi.Data;


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAuthentication().AddJwtBearer();


builder.Services.AddHttpContextAccessor();
// builder.Services.AddAuthentication().AddJwtBearer();
// builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("ToDoList"));

builder.Services.AddProductManagerEndpoints();
builder.Services.AddTaskManagerEndpoints();

// var connectionString = builder.Configuration.GetConnectionString("Todos") ?? "Data Source=.db/Todos.db";
// builder.Services.AddSqlite<TodoDbContext>(connectionString);

var app = builder.Build();

// app.UseCors();
// app.UseAuthentication();
// app.UseAuthorization();


app.MapProductManagerEndpoints();
app.MapTaskManagerEndpoints();


using (var Scope = app.Services.CreateScope())
{
	var context = Scope.ServiceProvider.GetRequiredService<ApiDbContext>();
	context.Database.EnsureCreated();
}

app.Run();
