using System.Threading;
using System.Threading.Tasks;

using Agrio.PIM.Service.Data;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;

namespace Agrio.PIM.Service.Features.Products.CreateProduct;

public sealed class CreateProductHandler
	(ServiceDbContext db) : ICommandHandler<CreateProductCommand, CreateProductResult> {
	public async Task<CreateProductResult> ExecuteAsync(CreateProductCommand command, CancellationToken ct) {
		var mapper = new Mapper();

		var product = mapper.ToEntity(command);
		db.Products.Add(product);
		await db.SaveChangesAsync(ct);

		var response = mapper.FromEntity(product);

		return response;
	}
}
