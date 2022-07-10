using CommandNetLib;
using Packets;
using Server;
using Server.CommandHandlers;
using SharedModel;

namespace Sandbox
{
    public class Server : IDisposable
    {
        private readonly NetLibServer _server;
        private readonly RoomRegistry _roomRegistry;
        private readonly MatchmakingSystem _matchmakingSystem;
        private readonly PlayersRegistry _playersRegistry;

        public Server()
        {
            _server = new NetLibServer(9050);
            _server.RegisterTypes<PacketsRegistry>();
            _server.RegisterTypes<SharedModelTypes>();
            _server.PlayerConnected += OnPlayerConnected;
            _server.Start();

            _matchmakingSystem = new MatchmakingSystem();
            _roomRegistry = new RoomRegistry();
            _playersRegistry = new PlayersRegistry();
            
            var registerPlayerInGameCommand = new CommandBuilder<RegisterInMatchmaking>()
                .BindHandler(new RegisterInMatchmakingCommandHandler(_matchmakingSystem, _playersRegistry))
                .Build();

            _server.RegisterCommand(registerPlayerInGameCommand);

            _matchmakingSystem.PlayersReadyForGame += _roomRegistry.CreateRoom;
            _matchmakingSystem.Start();
        }

        private void OnPlayerConnected(RemoteClient client)
        {
            Console.WriteLine($"[Server] Player {client} connected");
            client.SendPacket(new ConnectToServerApprove { PlayerID = client.Id });
            var player = new Player(client);
            _playersRegistry.Add(player);
        }

        public void Tick()
        {
            _server.PollEvents();
        }

        public void Dispose()
        {
            _server.Stop();
        }
    }
}
