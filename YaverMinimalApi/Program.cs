global using FastEndpoints;

using System.Text.Json;

using ApiLib.Auth;

using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;
using Agrio.Todo.ServiceBase.Features.Tasks.CreateTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTask;
using Agrio.Todo.ServiceBase.Features.Tasks.GetTasks;
using Agrio.Todo.ServiceBase.Features.Tasks.UpdateTask;

using FluentValidation.Results;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using YaverMinimalApi.Exceptions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(o =>
	o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);


builder.Services
	.AddFastEndpoints(o => { o.IncludeAbstractValidators = true; })
	.AddAuthorization()
	.AddAuthentication(XUserInfoAuthenticationHandler.SchemeName)
	.AddScheme<AuthenticationSchemeOptions, XUserInfoAuthenticationHandler>(
		XUserInfoAuthenticationHandler.SchemeName,
		null
	);

//builder.Services
//	.AddAuthentication(o => {
//		o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//		o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//	})
//	.AddJwtBearer(o => {
//		o.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
//		o.Audience = builder.Configuration["Auth0:Audience"];
//	});

var app = builder.Build();

app
	.UseOpisExceptionHandler(logStructuredException: true)
	.UseAuthentication()
	.UseAuthorization()
	.UseFastEndpoints(c =>
	{
		c.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
		// c.Errors.UseProblemDetails();
		c.Endpoints.Configurator = (ep) => { ep.PreProcessors(Order.Before, new MyRequestLogger()); };
		//https://fast-endpoints.com/docs/configuration-settings#customizing-error-responses
		// c.Errors.ResponseBuilder = (failures, ctx, statusCode) => {
		// 	return new ValidationProblemDetails(
		// 		failures.GroupBy(f => f.PropertyName)
		// 			.ToDictionary(
		// 				e => e.Key,
		// 				e => e.Select(m => m.ErrorMessage).ToArray())) {
		// 		Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
		// 		Title = "One or more validation errors occurred.",
		// 		Status = statusCode,
		// 		Instance = ctx.Request.Path,
		// 		Extensions = { { "traceId", ctx.TraceIdentifier } }
		// 	};
		// };
	});


app.MapRemote("http://localhost:6000", c =>
{
	c.ChannelOptions.MaxRetryAttempts = 3;
	//c.ChannelOptions.HttpHandler = new() { ... };
	//c.ChannelOptions.ServiceConfig = new() { ... };
	c.Register<CreateProductCommand, CreateProductResult>();
	c.Register<GetProductsCommand, GetProductsResult>();
	c.Register<GetProductCommand, GetProductResult>();
	c.Register<UpdateProductCommand, UpdateProductResult>();
});

// app.MapRemote("http://localhost:6001", c => {
// 	c.Register<CreateTaskCommand, CreateTaskResult>();
// 	c.Register<GetTasksCommand, GetTasksResult>();
// 	c.Register<GetTaskCommand, GetTaskResult>();
// 	c.Register<UpdateTaskCommand, UpdateTaskResult>();
// });

app.Run();


public class MyRequestLogger : IGlobalPreProcessor
{
	public async Task PreProcessAsync(object req, HttpContext ctx, List<ValidationFailure> failures,
		CancellationToken ct)
	{
		await Task.CompletedTask;
		// var logger = ctx.RequestServices.GetRequiredService<ILogger>();
		// logger.LogInformation($"request:{req?.GetType().FullName} path: {ctx.Request.Path}");

		var userInfo = ctx.Request.Headers["X-UserId"].FirstOrDefault();
		// if (userInfo == null) {
		// 	failures.Add(new("MissingHeaders", "The [X-UserId] header needs to be set!"));
		// 	await ctx.Response.SendErrorsAsync(failures, cancellation: ct); //sending response here
		// 	return;
		// }


		Console.WriteLine("userInfo:------------------");
		Console.WriteLine($"{userInfo}");
		Console.WriteLine("------------------");
		Console.WriteLine(
			$"roles: {JsonSerializer.Serialize(ctx.User?.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList())}");
		Console.WriteLine("------------------");
		Console.WriteLine($"request:{req?.GetType().FullName} path: {ctx.Request.Path}");
		Console.WriteLine("------------------");
	}
}
