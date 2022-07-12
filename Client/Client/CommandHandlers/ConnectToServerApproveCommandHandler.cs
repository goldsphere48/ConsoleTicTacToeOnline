using CommandNetLib;
using Packets;

namespace Client.CommandHandlers
{
    internal class ConnectToServerApproveCommandHandler : Command<ConnectToServerApprove>
    {
        private readonly Player _player;

        public ConnectToServerApproveCommandHandler(Player player)
        {
            _player = player;
        }

        public override void Handle(ConnectToServerApprove payload)
        {
            _player.Id = payload.PlayerID;
        }
    }
}
