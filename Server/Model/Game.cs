using SharedModel;

namespace Model
{
    public class Game
    {
        private Map _map = new Map();

        public Game(PlayerData firstPlayer, PlayerData secondPlayer)
        {
            TurnManager = new TurnManager(firstPlayer, secondPlayer);
        }

        public TurnManager TurnManager { get; }

        public void MakeTurn(int x, int y)
        {
            // _map.MarkCell(x, y, TurnManager.CurrentPlayer.Type);
        }
    }
}