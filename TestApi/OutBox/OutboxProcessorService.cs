using Infrastructure;

namespace API.OutBox
{
    public class OutboxProcessorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public OutboxProcessorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var messages = context.OutboxMessages.Where(x => !x.Processed).ToList();

                    foreach (var message in messages)
                    {
                        // meesage send for user 
                       

                        message.Processed = true;
                        context.Update(message);
                    }

                    await context.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }

}
