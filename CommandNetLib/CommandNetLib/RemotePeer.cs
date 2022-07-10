using LiteNetLib;
using LiteNetLib.Utils;

namespace CommandNetLib
{
    public class RemotePeer
    {
        private readonly NetPacketProcessor _netPacketProcessor;
        protected readonly NetPeer Peer;

        protected RemotePeer(NetPeer peer, NetPacketProcessor netPacketProcessor)
        {
            Peer = peer;
            _netPacketProcessor = netPacketProcessor;
        }

        public int Id => Peer.Id;

        public void SendPacket<T>(T payload, DeliveryMethod deliveryMethod = DeliveryMethod.ReliableOrdered) where T : struct, INetSerializable
        {
            var packet = new Packet<T>(payload, default);
            _netPacketProcessor.SendNetSerializable(Peer, packet, deliveryMethod);
        }

        public override string ToString()
        {
            return $"{GetType().Name}:\nID: {Peer.Id}\nEndPoint: {Peer.EndPoint}";
        }
    }
}
