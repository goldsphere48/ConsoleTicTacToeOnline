using CommandNetLib;
using Packets;

namespace Server.CommandHandlers
{
    internal class AcceptGameCommandHandler : Command<AcceptGame>
    {
        private readonly RoomRegistry _roomRegistry;

        public AcceptGameCommandHandler(RoomRegistry roomRegistry)
        {
            _roomRegistry = roomRegistry;
        }

        public override void Handle(AcceptGame payload)
        {
            var room = _roomRegistry.FindRoomWithPlayer(payload.PlayerId);

            if (payload.IsAccepted)
                room.MarkPlayerAsReady();
            else
                room.MarkPlayerAsNotReady();
        }
    }
}
