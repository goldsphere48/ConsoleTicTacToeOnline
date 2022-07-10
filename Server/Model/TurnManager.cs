using SharedModel;

namespace Model
{
    public class TurnManager
    {
        private PlayerData _firstPlayer;
        private PlayerData _secondPlayer;

        public TurnManager(PlayerData player1, PlayerData player2)
        {
            _firstPlayer = player1;
            _secondPlayer = player2;

            CurrentPlayer = new Random().Next() % 2 == 0 ? player1 : player2;
        }

        public PlayerData CurrentPlayer { get; private set; }


        public void SwitchTurn()
        {
            CurrentPlayer = CurrentPlayer.Id == _firstPlayer.Id ? _secondPlayer : _firstPlayer;
        }
    }
}
