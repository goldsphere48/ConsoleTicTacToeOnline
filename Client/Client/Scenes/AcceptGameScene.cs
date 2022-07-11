using Client.UI;
using CommandNetLib;
using Packets;

namespace Client.Scenes
{
    internal class AcceptGameScene : ConsoleScene
    {
        private readonly RemoteServer _server;
        private readonly Player _player;
        private bool _isDecided;

        public AcceptGameScene(RemoteServer server, Player player)
        {
            _player = player;
            _server = server;
            AddNode(new Label("Accept game ? (y/n)"));
        }

        public override void OnEnable()
        {
            string answer = "";
            do
            {
                answer = Console.ReadLine();
            } while (answer != "y" && answer != "n");

            switch (answer)
            {
                case "y":
                    _server.SendPacket(new AcceptGame { IsAccepted = true, PlayerId = _player.Id });
                    break;
                case "n":
                    _server.SendPacket(new AcceptGame { IsAccepted = false, PlayerId = _player.Id });
                    break;
            }
        }
    }
}
