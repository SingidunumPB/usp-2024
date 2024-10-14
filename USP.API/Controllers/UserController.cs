using Microsoft.AspNetCore.Mvc;
using USP.API.Services;
using USP.Application.Users.Commands;

namespace USP.API.Controllers;

public class UserController(IUserService userService, IProductService productService) : ApiBaseController
{
    [HttpPost]
    public async Task<ActionResult> Edit(EditUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        return Ok();
    }
}