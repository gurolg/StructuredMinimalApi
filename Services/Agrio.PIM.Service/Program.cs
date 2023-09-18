using Agrio.PIM.Service.Data;
using Agrio.PIM.Service.Features.Products.CreateProduct;
using Agrio.PIM.Service.Features.Products.GetProduct;
using Agrio.PIM.Service.Features.Products.GetProducts;
using Agrio.PIM.Service.Features.Products.UpdateProduct;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Accept only HTTP/2 to allow insecure connections for development.
builder.WebHost.ConfigureKestrel(o => o.ListenLocalhost(6000, c => c.Protocols = HttpProtocols.Http2));
builder.AddHandlerServer();


builder.Services.AddDbContext<ServiceDbContext>(options => options.UseInMemoryDatabase("PIM"));


var app = builder.Build();


app.MapHandlers(h => {
	h.Register<CreateProductCommand, CreateProductHandler, CreateProductResult>();
	h.Register<GetProductsCommand, GetProductsCommandHandler, GetProductsResult>();
	h.Register<GetProductCommand, GetProductCommandHandler, GetProductResult>();
	h.Register<UpdateProductCommand, UpdateProductCommandHandler, UpdateProductResult>();
});

using (var scope = app.Services.CreateScope()) {
	var context = scope.ServiceProvider.GetRequiredService<ServiceDbContext>();
	context.Database.EnsureCreated();
}

app.Run();
