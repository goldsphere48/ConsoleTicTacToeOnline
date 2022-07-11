using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.UI;
using CommandNetLib;
using Packets;

namespace Client.Scenes
{
    class SearchGameScene : ConsoleScene
    {
        private readonly Label _label;
        private readonly string _labelText = "Searching game ...";
        private string _points;
        private readonly RemoteServer _server;
        private readonly Player _player;

        public SearchGameScene(RemoteServer server, Player player)
        {
            _player = player;
            _server = server;
            _label = new Label(_labelText);
            AddNode(_label);
        }

        public override void OnEnable()
        {
            _server.SendPacket(new RegisterInMatchmaking { Id = _player.Id });
        }
    }
}
