using LiteNetLib;
using LiteNetLib.Utils;

namespace CommandNetLib
{
    public class RemoteServer : RemotePeer
    {
        public RemoteServer(NetPeer peer, NetPacketProcessor netPacketProcessor) : base(peer, netPacketProcessor)
        {
        }
    }
}
