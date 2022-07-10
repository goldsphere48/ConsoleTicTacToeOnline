using LiteNetLib;
using LiteNetLib.Utils;

namespace CommandNetLib
{
    public class RemoteClient : RemotePeer
    {
        public RemoteClient(NetPeer peer, NetPacketProcessor netPacketProcessor) : base(peer, netPacketProcessor)
        {
        }
    }
}
