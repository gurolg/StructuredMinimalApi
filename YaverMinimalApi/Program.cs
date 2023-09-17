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

app.UseFastEndpoints();

using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    context.Database.EnsureCreated();
}

app.Run();