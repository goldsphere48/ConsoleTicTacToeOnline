using CommandNetLib;
using SharedModel;

namespace Server
{
    internal class Player
    {
        public Player(RemoteClient client)
        {
            RemoteClient = client;
            Data = new PlayerData { Id = client.Id };
        }

        public RemoteClient RemoteClient { get; }
        public PlayerData Data { get; }
        public int Id => RemoteClient.Id;
    }
}
