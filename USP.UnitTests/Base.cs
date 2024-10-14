using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace USP.UnitTests;

public class Base
{
    public readonly HttpClient AnonymousClient;
    public readonly IMediator Mediator;


    public Base()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

        AnonymousClient = factory.CreateClient();
        Mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
    }
}