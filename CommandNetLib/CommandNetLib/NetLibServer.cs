using System.Net;
using LiteNetLib;

namespace CommandNetLib
{
    public class NetLibServer : NetLibCommon
    {
        public NetLibServer(int port) : base(port)
        {
            Listener.PeerConnectedEvent += OnPeerConnectedEvent;
            Listener.ConnectionRequestEvent += OnConnectionRequestEvent;
            Listener.PeerDisconnectedEvent += OnNetworkReceiveUnconnectedEvent;
        }

        private void OnNetworkReceiveUnconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            PlayerUnconnected?.Invoke(new RemoteClient(peer, NetPacketProcessor));
        }

        public event Action<RemoteClient> PlayerConnected;
        public event Action<RemoteClient> PlayerUnconnected;

        public override void Start()
        {
            NetManager.Start(Port);
        }

        public override void Stop()
        {
            NetManager.Stop();
        }

        private void OnConnectionRequestEvent(ConnectionRequest request)
        {
            request.Accept();
        }

        private void OnPeerConnectedEvent(NetPeer peer)
        {
            var remoteClient = new RemoteClient(peer, NetPacketProcessor);
            PlayerConnected?.Invoke(remoteClient);
        }
    }
}
