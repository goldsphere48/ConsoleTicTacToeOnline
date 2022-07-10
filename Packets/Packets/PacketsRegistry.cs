using CommandNetLib;

namespace Packets
{
    public class PacketsRegistry : TypesRegistry
    {
        public override void RegisterPackets()
        {
            RegisterPacket<WelcomePacket>();
            RegisterPacket<ConnectToServerApprove>();
            RegisterPacket<RegisterInMatchmaking>();
        }
    }
}
