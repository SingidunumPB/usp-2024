namespace USP.API.Services;

public interface IUserService
{
    Task<string> Get();
    Task<string> Create();
}