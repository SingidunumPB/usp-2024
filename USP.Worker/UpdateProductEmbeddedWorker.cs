using Microsoft.Extensions.Hosting;
using MongoDB.Entities;
using USP.Application.Common.Interfaces;
using USP.Application.Common.Mappers;
using USP.Domain.Entities;

namespace USP.Worker;

public class UpdateProductEmbeddedWorker(IProductService productService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // var now = DateTime.Now;
        
            // if (now.DayOfWeek is DayOfWeek.Monday or DayOfWeek.Wednesday or DayOfWeek.Friday && now is { Hour: 11, Minute: 0, Second: 0 })
            // {
            //     DoWork();
            // }
            
            await DoWorkAsync();
        
            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
        }
    }
    
    private async Task DoWorkAsync()
    {
        await DB.Database<ProductEmbedded>().DropCollectionAsync(nameof(ProductEmbedded));
        
        var results = await productService.GetAllProductsAsync(new CancellationToken());

        foreach (var entity in results)
        {
            var entityProductEmbedded = await entity.ToEmbedded();

            await entityProductEmbedded.SaveAsync();
        }
    }
}
