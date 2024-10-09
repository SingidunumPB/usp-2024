namespace USP.API.Services;

public class ProductService : IProductService
{
    public async Task<string>Get() => "Petar";

    public async Task<string> Create() => "Created!";
}