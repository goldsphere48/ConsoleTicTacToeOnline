using CommandNetLib;
using Packets;

namespace Client.CommandHandlers
{
    internal class ConnectToServerApproveCommandHandler : ICommandHandler<ConnectToServerApprove>
    {
        private readonly Player _player;

        public ConnectToServerApproveCommandHandler(Player player)
        {
            _player = player;
        }

        public void Handle(ConnectToServerApprove payload)
        {
            _player.Id = payload.PlayerID;
        }
    }
}
