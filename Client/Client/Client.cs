using Client.CommandHandlers;
using CommandNetLib;
using LiteNetLib.Utils;
using Packets;
using SharedModel;

namespace Client
{
    public class Client : IDisposable
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

            var setPlayerIdCommand = new CommandBuilder<ConnectToServerApprove>()
                .BindHandler(new ConnectToServerApproveCommandHandler(player))
                .Build();

            var readyForGameCommand = new CommandBuilder<ReadyForGame>()
                .BindHandler(new ReadyForGameCommandHandler())
                .Build();

            _client.RegisterCommand(setPlayerIdCommand);
            _client.RegisterCommand(readyForGameCommand);
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

        public void StartListening()
        {
            var pollEventsTask = new Task(PollEvents);
            pollEventsTask.Start();
        }

        private void OnConnectedToServer(RemoteServer server)
        {
            RemoteServer = server;
            Console.WriteLine($"[Client] Connection to server {server}");
        }

        private void PollEvents()
        {
            while (true)
            {
                _client.PollEvents();
                Thread.Sleep(100);
            }
        }

        public void Dispose()
        {
            _client.Stop();
            _client.ConnectedToServer -= OnConnectedToServer;
        }
    }
}
