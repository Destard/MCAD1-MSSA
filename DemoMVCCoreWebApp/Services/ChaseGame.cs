namespace DemoMVCCoreWebApp.Services
{
    public class ChaseGame : IChaseGame
    {

        //Position and target are center-points: Coordinates to the client are top-left corner.
        private readonly Coordinates _PlayerSize = new () { X = 20, Y = 20 };
        private readonly Coordinates _ArenaSize = new () { X = 500, Y = 500 };
        public event EventHandler GameOver;
        public event EventHandler GameProgress;
        private Timer _gameTimer;
        public GameState GameState { get; set; }
        public ChaseGame()
        {
            GameState = new GameState();
            InitializeGame();
        }
        public void InitializeGame()
        {
            GameState = new GameState()
            {
                WinnerID = "",
                Players = new List<Player>()
                {
                    new Player()
                    {
                        ClientID = "",
                        PlayerPosition = new Coordinates(){ X = _PlayerSize.X/2, Y = _ArenaSize.Y/2 + _PlayerSize.Y/2 },
                        PlayerTarget = new Coordinates(){ X = _PlayerSize.X/2, Y = _ArenaSize.Y/2 + _PlayerSize.Y/2 },
                        PlayerSize = new Coordinates(){ X = _PlayerSize.X, Y = _PlayerSize.Y },
                        PlayerVelocity = new Coordinates(){ X = 0, Y = 0 }
                    },
                    new Player()
                    {
                        ClientID = "",
                        PlayerPosition = new Coordinates(){ X = _ArenaSize.X - _PlayerSize.X/2, Y = _ArenaSize.Y/2 + _PlayerSize.Y/2 },
                        PlayerTarget = new Coordinates(){ X = _ArenaSize.X - _PlayerSize.X/2, Y = _ArenaSize.Y/2 + _PlayerSize.Y/2 },
                        PlayerSize = new Coordinates(){ X = _PlayerSize.X, Y = _PlayerSize.Y },
                        PlayerVelocity = new Coordinates(){ X = 0, Y = 0 }
                    }
                }
            };
        }
        public void StartGame()
        {
            _gameTimer = new Timer(new TimerCallback(MovePlayers), GameState, 0, 100);
        }
        public void MovePlayers(object input)
        {
            GameState gameState = input as GameState;
            //Move players based on current velocity.
            //Check for collision.
            //Adjust velocity based on target.
            foreach (Player p in gameState.Players)
            {
                MovePlayer(p);
            }
            CheckForCollisions(gameState.Players);
            // if (gameState.Players.Count(p => !p.IsDead) <= 1)
            // {
            //     gameState.WinnerID = gameState.Players.First(p => !p.IsDead).ClientID;
            //     GameOver(this,EventArgs.Empty);
            //     _gameTimer.Dispose();
            //     return;
            // }
            //else { 
                AdjustPlayerVelocities(GameState.Players);
            //}
            //GameProgress(this, EventArgs.Empty);
        }

        private void CheckForCollisions(List<Player> players)
        {
            for (int x = 0; x < players.Count-1;x++)
            {
                if (CheckForCollision(players[x],players[x+1]))
                {
                    ResolveCollision(players[x], players[x + 1]);
                }
            }
        }

        private void ResolveCollision(Player player1, Player player2)
        {
            var player1Speed = player1.PlayerVelocity.X + player1.PlayerVelocity.Y;
            var player2Speed = player2.PlayerVelocity.X + player2.PlayerVelocity.Y;
            if (player1Speed > player2Speed)
            {
                player2.IsDead = true;
            }
            else
            {
                player1.IsDead = true;
            }
        }

        private bool CheckForCollision(Player player1, Player player2)
        {
            if (Math.Abs(player1.PlayerPosition.X - player2.PlayerPosition.X) < player1.PlayerSize.X/2 + player2.PlayerSize.X/2
                && Math.Abs(player1.PlayerPosition.Y - player2.PlayerPosition.Y) < player1.PlayerSize.Y / 2 + player2.PlayerSize.Y / 2)
            {
                //Collision!
                return true;
            }
            return false;
        }
        private void AdjustPlayerVelocity(Player p)
        {
            var xDistance = p.PlayerTarget.X - p.PlayerPosition.X;
            var yDistance = p.PlayerTarget.Y - p.PlayerPosition.Y;

            p.PlayerVelocity.X += xDistance/25;
            p.PlayerVelocity.Y += yDistance/25;
        }
        private void AdjustPlayerVelocities(List<Player> players)
        {
            foreach (var p in players)
            {
                AdjustPlayerVelocity(p);
            }
        }

        private void MovePlayer(Player p)
        {
            p.PlayerPosition.X += p.PlayerVelocity.X;
            p.PlayerPosition.Y += p.PlayerVelocity.Y;
        }

        public void SetPlayerTarget(string ClientID, Coordinates coordinates)
        {
            GameState.Players.First(p => p.ClientID == ClientID).PlayerTarget = coordinates;
        }

        public void JoinGame(string ClientID)
        {
            //Find the first available player and set their clientID to the new joiner.
            var firstOpenPlayer = GameState.Players.FirstOrDefault(p => p.ClientID == "");
            if (firstOpenPlayer != null) firstOpenPlayer.ClientID = ClientID;
        }
    }
}
