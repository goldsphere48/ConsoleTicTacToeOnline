using Client.Scenes;
using CommandNetLib;
using Packets;

namespace Client.CommandHandlers
{
    internal class StartGameCommandHandler : Command<StartGame>
    {
        public override void Handle(StartGame payload)
        {
            ConsoleSceneManager.Instance.RegisterScene(new GameScene(payload.PlayerType));
            ConsoleSceneManager.Instance.ActivateScene<GameScene>();
        }
    }
}
