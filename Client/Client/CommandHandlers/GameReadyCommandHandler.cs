using Client.Scenes;
using CommandNetLib;
using Packets;

namespace Client.CommandHandlers
{
    internal class GameReadyCommandHandler : Command<GameReady>
    {
        public override void Handle(GameReady payload)
        {
            ConsoleSceneManager.Instance.ActivateScene<AcceptGameScene>();
        }
    }
}
