using CommandNetLib;
using Model;
using Packets;

namespace Server.CommandHandlers
{
    internal class RegisterInMatchmakingCommandHandler : ICommandHandler<RegisterInMatchmaking>
    {
        private readonly MatchmakingSystem _matchmakingSystem;
        private readonly PlayersRegistry _playersRegistry;

        public RegisterInMatchmakingCommandHandler(MatchmakingSystem matchmakingSystem, PlayersRegistry playersRegistry)
        {
            _matchmakingSystem = matchmakingSystem;
            _playersRegistry = playersRegistry;
        }

        public void Handle(RegisterInMatchmaking payload)
        {
            _matchmakingSystem.AddPlayerInQueue(_playersRegistry[payload.Id]);
        }
    }
}
