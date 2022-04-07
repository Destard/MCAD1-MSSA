namespace DemoMVCCoreWebApp.Services
{
    public interface IChaseGame
    {
        event EventHandler GameOver;
        event EventHandler GameProgress;
        bool IsPlaying { get; }
        GameState GameState { get; set; }
        void SetPlayerTarget(string ClientID, Coordinates coordinates);
        void JoinGame(string ClientID);
        void StartGame();
        
    }
    public class GameState
    {
        public List<Player> Players{ get; set; }
        public string WinnerID { get; set; }
    }
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Player
    {
        /// <summary>
        /// The ID of the client that is controlling this character.
        /// </summary>
        public string ClientID { get; set; }
        public bool IsDead { get; set; }
        public Coordinates PlayerPosition { get; set; }
        public Coordinates PlayerTarget { get; set; }
        public Coordinates PlayerVelocity { get; set; }
        public Coordinates PlayerSize { get; set; }
    }
}
