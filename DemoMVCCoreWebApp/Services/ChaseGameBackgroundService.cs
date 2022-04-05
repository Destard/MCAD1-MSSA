using DemoMVCCoreWebApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DemoMVCCoreWebApp.Services
{
    public class ChaseGameBackgroundService : BackgroundService
    {
        private readonly IHubContext<ChaseHub> _hubContext;
        private IChaseGame _chaseGame;
        public ChaseGameBackgroundService(IHubContext<ChaseHub> hubContext, IChaseGame chaseGame)
        {
            _chaseGame = chaseGame;
            _hubContext = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.SendAsync("GameProgress", _chaseGame.GameState);
                await Task.Delay(100);
            }
        }
    }
}
