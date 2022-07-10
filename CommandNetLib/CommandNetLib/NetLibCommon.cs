using LiteNetLib;
using LiteNetLib.Utils;

namespace CommandNetLib
{
    public abstract class NetLibCommon : ICommandRegister
    {
        protected readonly NetManager NetManager;
        protected readonly EventBasedNetListener Listener;
        protected readonly NetPacketProcessor NetPacketProcessor;
        protected readonly int Port;

        protected NetLibCommon(int port)
        {
            Listener = new EventBasedNetListener();
            Listener.NetworkReceiveEvent += OnNetworkReceiveEvent;
            NetPacketProcessor = new NetPacketProcessor();
            NetManager = new NetManager(Listener);
            Port = port;
        }

        public void RegisterPacketHandler<T>(Action<Packet<T>> handler) where T : struct, INetSerializable
        {
            NetPacketProcessor.SubscribeNetSerializable(handler);
        }

        public void RegisterCommands<T>() where T : CommandsRegistry
        {
            var registry = Activator.CreateInstance<T>();
            registry.Initialize(this);
            registry.RegisterCommands();
        }

        public void RegisterCommand<T>(Command<T> command) where T : struct, INetSerializable
        {
            NetPacketProcessor.SubscribeNetSerializable<Packet<T>>(command.Handle);
        }

        public void RegisterTypes<T>() where T : TypesRegistry
        {
            var registry = Activator.CreateInstance<T>();
            registry.Initialize(NetPacketProcessor);
            registry.RegisterPackets();
        }

        private void OnNetworkReceiveEvent(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
        {
            NetPacketProcessor.ReadAllPackets(reader, peer);
        }

        public void PollEvents()
        {
            NetManager.PollEvents();
        }

        public abstract void Start();
        public abstract void Stop();
    }
}
