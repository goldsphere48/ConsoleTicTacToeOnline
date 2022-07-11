using Packets;

namespace Server
{
    internal class RoomRegistry
    {
        private readonly Dictionary<Guid, Room> _rooms;
        private readonly Dictionary<Guid, Room> _roomsWithPlayersId;

        public RoomRegistry()
        {
            _rooms = new Dictionary<Guid, Room>();
            _roomsWithPlayersId = new Dictionary<Guid, Room>();
        }

        public void CreateRoom(Player firstPlayer, Player secondPlayer)
        {
            var guid = Guid.NewGuid();
            var room = new Room(firstPlayer, secondPlayer, guid);
            _rooms.Add(guid, room);
            _roomsWithPlayersId.Add(firstPlayer.Id, room);
            _roomsWithPlayersId.Add(secondPlayer.Id, room);
            SendReadyMessage(firstPlayer, guid);
            SendReadyMessage(secondPlayer, guid);
        }

        public void SendReadyMessage(Player player, Guid roomId)
        {
            player.RemoteClient.SendPacket(new GameReady { RoomID = roomId });
        }

        public Room FindRoomWithPlayer(Guid playerId)
        {
            return _roomsWithPlayersId[playerId];
        }

        public void CloseRoom(Guid roomId)
        {
            var room = _rooms[roomId];
            CloseRoom(room);
        }

        public void CloseRoom(Room room)
        {
            if (room != null)
            {
                room.Close();
                _rooms.Remove(room.Id);
                foreach (var player in room.Players)
                {
                    _roomsWithPlayersId.Remove(player.Id);
                }
            }
        }

        public Room? FindRoomWithPlayer(Player player)
        {
            if (_roomsWithPlayersId.ContainsKey(player.Id))
                return _roomsWithPlayersId[player.Id];

            return null;
        }
    }
}
