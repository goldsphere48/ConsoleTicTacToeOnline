using Client.CommandHandlers;
using CommandNetLib;
using LiteNetLib.Utils;
using Packets;
using SharedModel;

namespace Client
{
    public class Client : IDisposable, ITickable
    {
        private readonly NetLibClient _client;
        private readonly Player _player;

        public Client(Player player)
        {
            _player = player;
            _client = new NetLibClient();
            _client.RegisterTypes<PacketsRegistry>();
            _client.RegisterTypes<SharedModelTypes>();
            _client.ConnectedToServer += OnConnectedToServer;
            _client.RegisterPacketHandler<ConnectToServerApprove>(OnConnectApproveReceived);
            _client.Connect(9050);

            var setPlayerIdCommand = new ConnectToServerApproveCommandHandler(player);
            var readyForGameCommand = new GameReadyCommandHandler();
            var startGameCommand = new StartGameCommandHandler();

            _client.RegisterCommand(setPlayerIdCommand);
            _client.RegisterCommand(readyForGameCommand);
            _client.RegisterCommand(startGameCommand);
        }

        public RemoteServer RemoteServer { get; private set; }

        public void OnConnectApproveReceived(Packet<ConnectToServerApprove> packet)
        {
            _player.Id = packet.Payload.PlayerID;
        }

        public void RegisterPacketHandler<T>(Action<Packet<T>> handler) where T : struct, INetSerializable
        {
            _client.RegisterPacketHandler(handler);
        }

        private void OnConnectedToServer(RemoteServer server)
        {
            RemoteServer = server;
            Console.WriteLine($"[Client] Connection to server {server}");
        }

        public void Dispose()
        {
            _client.Stop();
            _client.ConnectedToServer -= OnConnectedToServer;
        }

        public void Tick()
        {
            _client.PollEvents();
        }
    }
}
