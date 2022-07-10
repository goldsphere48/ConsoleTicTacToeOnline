namespace Server
{
    internal class PlayersRegistry
    {
        private readonly Dictionary<int, Player> _players;

        public PlayersRegistry()
        {
            _players = new Dictionary<int, Player>();
        }

        public void Add(Player player)
        {
            _players[player.Id] = player;
        }

        public Player this[int index]
        {
            get
            {
                if (!_players.ContainsKey(index))
                    throw new InvalidOperationException();

                return _players[index];
            }
        }
    }
}
