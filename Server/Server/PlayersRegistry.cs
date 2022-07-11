using System.Net;
using CommandNetLib;

namespace Server
{
    internal class PlayersRegistry
    {
        private readonly Dictionary<Guid, Player> _players;

        public PlayersRegistry()
        {
            _players = new Dictionary<Guid, Player>();
        }

        public void Add(Player player)
        {
            _players[player.Id] = player;
        }

        public Player this[Guid index]
        {
            get
            {
                if (!_players.ContainsKey(index))
                    throw new InvalidOperationException();

                return _players[index];
            }
        }

        public void Remove(Player player)
        {
            _players.Remove(player.Id);
        }

        public Player? FindPlayerByPeerId(RemoteClient client)
        {
            return _players.Values.FirstOrDefault(p => p.RemoteClient.Id == client.Id);
        }
    }
}
