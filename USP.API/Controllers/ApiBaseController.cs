using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace USP.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApiBaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator
    {
        get { return _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>(); }
    }
}