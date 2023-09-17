using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agrio.PIM.Service.Data;
using Agrio.PIM.ServiceBase.Features.Products.GetProduct;
using Microsoft.EntityFrameworkCore;


namespace Agrio.PIM.Service.Features.Products.GetProduct;

public sealed class GetProductCommandHandler(ServiceDbContext _db) : ICommandHandler<GetProductCommand, GetProductResult>
{
	public async Task<GetProductResult> ExecuteAsync(GetProductCommand command, CancellationToken ct)
	{

		var _mapper = new Mapper();

		var product = await _db.Products
				.AsNoTracking()
				.Where(t => t.Id == command.Id)
				.FirstOrDefaultAsync(ct) ?? throw new Exception("Product not found");
		//TODO: Standardize exceptions

		var response = _mapper.FromEntity(product);

		return response;
	}
}
