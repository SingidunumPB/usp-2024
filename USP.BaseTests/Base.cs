using Microsoft.Extensions.DependencyInjection;

namespace USP.BaseTests;

public class Base
{
    public readonly HttpClient AnonymousClient;

    public Base()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        
        AnonymousClient = factory.CreateClient();
    }
}