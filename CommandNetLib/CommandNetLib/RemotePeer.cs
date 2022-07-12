using System.Net;
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
        public IPEndPoint IPEndPoint => Peer.EndPoint;

        public void SendPacket<T>(T payload, DeliveryMethod deliveryMethod = DeliveryMethod.ReliableOrdered) where T : struct, INetSerializable
        {
            var packet = new Packet<T>(payload, default);
            _netPacketProcessor.SendNetSerializable(Peer, packet, deliveryMethod);
        }

        public override string ToString()
        {
            return $"{GetType().Name}:\nID: {Peer.Id}\nEndPoint: {Peer.EndPoint}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is not RemotePeer)
                return false;

            return (obj as RemotePeer).Id == Peer.Id;
        }

        public static bool operator==(RemotePeer peer, RemotePeer other)
        {
            if (ReferenceEquals(peer, other))
                return true;
            if (ReferenceEquals(peer, null))
                return false;
            if (ReferenceEquals(other, null))
                return false;

            return other.Equals(peer);
        }

        public static bool operator !=(RemotePeer peer, RemotePeer other)
        {
            return !(peer == other);
        }
    }
}
