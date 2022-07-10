using Client.Scenes;
using CommandNetLib;
using Packets;

namespace Client.CommandHandlers
{
    internal class ReadyForGameCommandHandler : ICommandHandler<ReadyForGame>
    {
        public void Handle(ReadyForGame payload)
        {
            ConsoleSceneManager.Instance.ActivateScene<AcceptGameScene>();
        }
    }
}
