using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using USP.Application.Common.Interfaces;
using USP.Infrastructure.Services;

namespace USP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // var mongoDbConfiguration = new MongoDbConfiguration();
        var conn = configuration.GetSection("MongoDbConfiguration");

        var db = conn.GetSection("DbName").Value!;
        var conString = conn.GetSection("DbString").Value;
   
        Task.Run(async () => { await DB.InitAsync(db, MongoClientSettings.FromConnectionString(conString)); })
            .GetAwaiter()
            .GetResult();
        
        services.AddSingleton<IProductService, ProductService>();

        return services;
    }
}