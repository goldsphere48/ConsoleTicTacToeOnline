using CommandNetLib;
using SharedModel;

namespace Server
{
    internal class MatchmakingSystem : ITickable
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

        private Tuple<int, int> Generate2Id()
        {
            var random = new Random();
            var firstId = random.Next(0, _players.Count);
            int secondId = -1;
            while (firstId == secondId || secondId == -1)
            {
                secondId = random.Next(0, _players.Count);
            }
            return new Tuple<int, int>(firstId, secondId);
        }

        public void Tick()
        {
            if (_players.Count >= 2)
            {
                var ids = Generate2Id();
                var firstPlayer = _players[ids.Item1];
                var secondPlayer = _players[ids.Item2];
                _players.Remove(firstPlayer);
                _players.Remove(secondPlayer);
                PlayersReadyForGame?.Invoke(firstPlayer, secondPlayer);
            }
        }
    }
}
