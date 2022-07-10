using SharedModel;

namespace Server
{
    internal class MatchmakingSystem
    {
        private readonly List<Player> _players;
        private object locker = new object();

        public MatchmakingSystem()
        {
            _players = new List<Player>();
        }

        public event Action<Player, Player> PlayersReadyForGame;

        public void AddPlayerInQueue(Player player)
        {
            lock (locker)
            {
                _players.Add(player);
            }
        }

        public void Start()
        {
            void StartTask()
            {
                var random = new Random();
                while (true)
                {
                    if (_players.Count >= 2)
                    {
                        var firstPlayer = _players[random.Next(_players.Count)];
                        var secondPlayer = _players[random.Next(_players.Count)];
                        _players.Remove(firstPlayer);
                        _players.Remove(secondPlayer);
                        PlayersReadyForGame?.Invoke(firstPlayer, secondPlayer);
                    }
                }
            }

            Task startTask = new Task(StartTask);
            startTask.Start();
        }
    }
}
