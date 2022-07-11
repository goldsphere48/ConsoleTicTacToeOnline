using Client.Scenes;
using CommandNetLib;
using Packets;

namespace Client.CommandHandlers
{
    internal class GameReadyCommandHandler : ICommandHandler<GameReady>
    {
        public void Handle(GameReady payload)
        {
            ConsoleSceneManager.Instance.ActivateScene<AcceptGameScene>();
        }
    }
}
