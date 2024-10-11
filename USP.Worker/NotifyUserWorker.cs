using Microsoft.Extensions.Hosting;
using MongoDB.Entities;
using USP.Domain.Entities;

namespace USP.Worker;

public class NotifyUserWorker : BackgroundService
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
        
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
    
    private async Task DoWorkAsync()
    {
        var results = await DB.Find<User>().ExecuteAsync();

        foreach (var user in results)
        {
            Console.WriteLine(user.Email);
        }
    }
}
