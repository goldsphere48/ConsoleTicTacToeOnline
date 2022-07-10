using LiteNetLib.Utils;

namespace CommandNetLib
{
    public abstract class TypesRegistry
    {
        private NetPacketProcessor _netPacketProcessor = null!;

        internal void Initialize(NetPacketProcessor netPacketProcessor)
        {
            _netPacketProcessor = netPacketProcessor;
        }

        protected void RegisterPacket<T>() where T : struct, INetSerializable
        {
            RegisterType<Packet<T>>();
        }

        protected void RegisterType<T>() where T : struct, INetSerializable
        {
            _netPacketProcessor.RegisterNestedType<T>();
        }

        public abstract void RegisterPackets();
    }
}
