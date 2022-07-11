using CommandNetLib;
using SharedModel;

namespace Server
{
    internal class Player
    {
        public PlayerData Data;

        public Player(RemoteClient client)
        {
            RemoteClient = client;
            Id = Guid.NewGuid();
            Data = new PlayerData();
        }

        public RemoteClient RemoteClient { get; }
        public Guid Id { get; }
    };
}
