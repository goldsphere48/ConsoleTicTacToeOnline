using Packets;

namespace Server
{
    internal class RoomRegistry
    {
        private readonly Dictionary<Guid, Room> _rooms;

        public RoomRegistry()
        {
            _rooms = new Dictionary<Guid, Room>();
        }

        public void CreateRoom(Player firstPlayer, Player secondPlayer)
        {
            var guid = Guid.NewGuid();
            _rooms.Add(guid, new Room(firstPlayer, secondPlayer));
            SendReadyMessage(firstPlayer, guid);
            SendReadyMessage(secondPlayer, guid);
        }

        public void SendReadyMessage(Player player, Guid roomId)
        {
            player.RemoteClient.SendPacket(new ReadyForGame { RoomID = roomId });
        }
    }
}
