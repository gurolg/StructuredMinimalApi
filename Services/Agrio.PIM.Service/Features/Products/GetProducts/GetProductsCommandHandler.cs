using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agrio.PIM.Service.Data;
using Agrio.PIM.ServiceBase.Features.Products.GetProducts;
using Microsoft.EntityFrameworkCore;


namespace Agrio.PIM.Service.Features.Products.GetProducts;

public sealed class GetProductsCommandHandler(ServiceDbContext _db) : ICommandHandler<GetProductsCommand, GetProductsResult>
{
	public async Task<GetProductsResult> ExecuteAsync(GetProductsCommand command, CancellationToken ct)
	{

		var _mapper = new Mapper();

		var products = await _db.Products
				.AsNoTracking()
				.Where(t => string.IsNullOrEmpty(command.Term) || t.Title.Contains(command.Term))
				.ToListAsync();

		var response = _mapper.FromEntity(products);

		return response;
	}
}
