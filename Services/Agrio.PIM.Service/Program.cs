using Agrio.PIM.Service.Data;
using Agrio.PIM.Service.Features.Products.CreateProduct;
using Agrio.PIM.Service.Features.Products.GetProduct;
using Agrio.PIM.Service.Features.Products.GetProducts;
using Agrio.PIM.Service.Features.Products.UpdateProduct;
using Agrio.PIM.Service.Interceptors;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;

using Calzolari.Grpc.AspNetCore.Validation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Accept only HTTP/2 to allow insecure connections for development.
builder.WebHost.ConfigureKestrel(o => o.ListenAnyIP(6000, c => c.Protocols = HttpProtocols.Http2));
builder.AddHandlerServer(
	options =>
	{
		// options.Interceptors.Add<ServerLogInterceptor>();
		// options.Interceptors.Add<ServerFeaturesInterceptor>();
		// options.EnableMessageValidation();
	});


builder.Services.AddHttpContextAccessor();

//from lib
// builder.Services.AddValidator<IdRequestValidator>();

builder.Services.AddDbContext<ServiceDbContext>(options => options.UseInMemoryDatabase("PIM"));

builder.Services.AddGrpcValidation();

// builder.Services.AddSingleton<IValidatorErrorMessageHandler>(new CustomMessageHandler());

var app = builder.Build();


app.MapHandlers(h =>
{
	h.Register<CreateProductCommand, CreateProductHandler, CreateProductResult>();
	h.Register<GetProductsCommand, GetProductsCommandHandler, GetProductsResult>();
	h.Register<GetProductCommand, GetProductCommandHandler, GetProductResult>();
	h.Register<UpdateProductCommand, UpdateProductCommandHandler, UpdateProductResult>();
	//https://github.dev/FastEndpoints/Remote-Procedure-Call-Demo
	//h.RegisterServerStream<StatusStreamCommand, StatusUpdateHandler, StatusUpdate>();
	//h.RegisterClientStream<CurrentPosition, PositionProgressHandler, ProgressReport>();
	//h.RegisterEventHub<SomethingHappened>();
});

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();
	context.Database.EnsureCreated();
}


app.Run();
