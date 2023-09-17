using System.Threading;
using System.Threading.Tasks;
using Agrio.PIM.Service.Data;
using Agrio.PIM.ServiceBase.Features.Products.CreateProduct;


namespace Agrio.PIM.Service.Features.Products.CreateProduct;

public sealed class CreateProductHandler(ServiceDbContext _db) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> ExecuteAsync(CreateProductCommand command, CancellationToken ct)
    {
        var _mapper = new Mapper();

        var product = _mapper.ToEntity(command);
        _db.Products.Add(product);
        await _db.SaveChangesAsync(ct);

        var response = _mapper.FromEntity(product);

        return response;
    }
}
