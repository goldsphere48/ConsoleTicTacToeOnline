using System.Net;
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
            _server.PlayerUnconnected += OnPlayerUnconnected;
            _server.Start();

            _matchmakingSystem = new MatchmakingSystem();
            _roomRegistry = new RoomRegistry();
            _playersRegistry = new PlayersRegistry();

            var registerPlayerInGameCommand = new RegisterInMatchmakingCommandHandler(_matchmakingSystem, _playersRegistry);
            var acceptGameCommand = new AcceptGameCommandHandler(_roomRegistry);

            _server.RegisterCommand(registerPlayerInGameCommand);
            _server.RegisterCommand(acceptGameCommand);

            _matchmakingSystem.PlayersReadyForGame += _roomRegistry.CreateRoom;
        }

        private void OnPlayerUnconnected(RemoteClient client)
        {
            var player = _playersRegistry.FindPlayerByPeerId(client);
            _playersRegistry.Remove(player);
            var room = _roomRegistry.FindRoomWithPlayer(player);
            _roomRegistry.CloseRoom(room);
        }

        private void OnPlayerConnected(RemoteClient client)
        {
            Console.WriteLine($"[Server] Player {client} connected");
            var player = new Player(client);
            client.SendPacket(new ConnectToServerApprove { PlayerID = player.Id });
            _playersRegistry.Add(player);
        }

        public void Tick()
        {
            _server.PollEvents();
            _matchmakingSystem.Tick();
        }

        public void Dispose()
        {
            _server.Stop();
        }
    }
}
