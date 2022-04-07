using DemoMVCCoreWebApp.Services;
using Microsoft.AspNetCore.SignalR;

namespace DemoMVCCoreWebApp.Hubs
{
    public class ChaseHub : Hub
    {
        private IChaseGame _chaseGame;
        public ChaseHub(IChaseGame chaseGame)
        {
            _chaseGame = chaseGame;
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ClientConnected", _chaseGame.GameState);
            await base.OnConnectedAsync();
        }

        public async Task JoinGame()
        {
            _chaseGame.JoinGame(Context.ConnectionId);
            await Clients.Caller.SendAsync("PlayerJoined");
        }
        public async Task StartGame()
        {
            _chaseGame.StartGame();
        }
        public async Task SetPlayerPosition(Coordinates coordinates)
        {
            _chaseGame.SetPlayerTarget(Context.ConnectionId, coordinates);
        }
    }
}
