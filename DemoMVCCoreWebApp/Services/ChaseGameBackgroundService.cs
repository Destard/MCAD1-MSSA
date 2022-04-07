using DemoMVCCoreWebApp.Hubs;
using DemoMVCCoreWebApp.Utilities;
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
                if (_chaseGame.IsPlaying)
                    await _hubContext.Clients.All.SendAsync("GameProgress", _chaseGame.GameState);
                await Task.Delay(Globals.REFRESH_RATE);
            }
        }
    }
}
