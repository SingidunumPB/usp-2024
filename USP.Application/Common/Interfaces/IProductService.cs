using USP.Domain.Entities;

namespace USP.Application.Common.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
}