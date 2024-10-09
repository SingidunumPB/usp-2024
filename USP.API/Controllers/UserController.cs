using Microsoft.AspNetCore.Mvc;
using USP.API.Services;

namespace USP.API.Controllers;

public class UserController(IUserService userService, IProductService productService) : ApiBaseController
{
    [HttpGet]
    public async Task<string> Get() => await userService.Get();

    [HttpPost]
    public async Task<string> Create()
    {
        var result = await userService.Create();
        await productService.Create();
        return result;
    }
}