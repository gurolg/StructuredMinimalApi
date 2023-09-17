using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agrio.PIM.Service.Data;
using Agrio.PIM.ServiceBase.Features.Products.UpdateProduct;
using Microsoft.EntityFrameworkCore;


namespace Agrio.PIM.Service.Features.Products.UpdateProduct;

public sealed class UpdateProductCommandHandler(ServiceDbContext _db) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
	public async Task<UpdateProductResult> ExecuteAsync(UpdateProductCommand command, CancellationToken ct)
	{

		var _mapper = new Mapper();

		var product = await _db.Products
				.AsNoTracking()
				.Where(t => t.Id == command.Id)
				.FirstOrDefaultAsync(ct) ?? throw new Exception("Product not found");
		//TODO: Standardize exceptions


		product = _mapper.UpdateEntity(command, product);
		_db.Products.Update(product);
		await _db.SaveChangesAsync(ct);

		var response = _mapper.FromEntity(product);

		return response;
	}
}
