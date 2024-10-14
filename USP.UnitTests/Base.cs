using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Entities;

namespace USP.UnitTests;

public class Base : IAsyncLifetime
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

    public Task InitializeAsync()
    {
       return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await DB.Database("UspTests").Client.DropDatabaseAsync("UspTests");
    }
}