using System;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace BP.Api.BackgroundServices
{
    public class DataTimeLogWriter : IHostedService, IDisposable
    {
        private Timer timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(DataTimeLogWriter)} Service Started...");


            timer = new Timer(WriteDateTimeOnLog, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void WriteDateTimeOnLog(object state)
        {
            Console.WriteLine($" DateTime is {DateTime.Now.ToLongTimeString()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            timer?.Change(Timeout.Infinite, 0);

            Console.WriteLine($"{nameof(DataTimeLogWriter)} Service Stopped...");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer = null;
        }
    }

    public class DateTimeLogWriter2 : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
