using CommandNetLib;
using Model;
using Packets;
using SharedModel;

namespace Server
{
    class Room
    {
        private readonly Player _firstPlayer;
        private readonly Player _secondPlayer;
        private Game _game;
        private readonly Dictionary<Guid, Player> _players;
        private int _readyPlayersCount;
        private readonly Guid _roomId;

        public Room(Player firstPlayer, Player secondPlayer, Guid roomId)
        {
            _roomId = roomId;
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
            _players = new Dictionary<Guid, Player>();
            _players[_firstPlayer.Id] = firstPlayer;
            _players[_secondPlayer.Id] = secondPlayer;
        }

        public Guid Id => _roomId;

        public IEnumerable<Player> Players => _players.Values;

        public void MarkPlayerAsReady()
        {
            _readyPlayersCount++;
            if (_readyPlayersCount == 2)
            {
                var random = new Random();
                var firstType = random.Next() % 2;
                var secondType = firstType ^ 1;
                _firstPlayer.Data.Type = (PlayerType)firstType;
                _secondPlayer.Data.Type = (PlayerType)secondType;
                _game = new Game(_firstPlayer.Data, _secondPlayer.Data);
                SendStartGameMessage(_firstPlayer.RemoteClient, (PlayerType)firstType);
                SendStartGameMessage(_secondPlayer.RemoteClient, (PlayerType)secondType);
            }
        }

        public void SendStartGameMessage(RemoteClient client, PlayerType type)
        {
            client.SendPacket(new StartGame { PlayerType = type });
        }

        public void MarkPlayerAsNotReady()
        {
            Close();
        }

        public void Close()
        {
            
        }
    }
}
