namespace USP.API.Services;

public interface IProductService
{
    Task<string> Get();
    Task<string> Create();
}