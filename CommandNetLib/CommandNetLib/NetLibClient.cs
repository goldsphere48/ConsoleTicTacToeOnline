using LiteNetLib;

namespace CommandNetLib
{
    public class NetLibClient : NetLibCommon
    {
        private bool _isInitialized;

        public NetLibClient(int port = 0) : base(port)
        {
            Listener.PeerConnectedEvent += OnPeerConnectedEvent;
        }

        public event Action<RemoteServer> ConnectedToServer;

        private void OnPeerConnectedEvent(NetPeer peer)
        {
            ConnectedToServer?.Invoke(new RemoteServer(peer, NetPacketProcessor));
        }

        public override void Start()
        {
            if (!_isInitialized)
            {
                if (Port == 0)
                    NetManager.Start();
                else
                    NetManager.Start(Port);

                _isInitialized = true;
            }
        }

        public override void Stop()
        {
            _isInitialized = false;
            NetManager.Stop();
        }

        public void Connect(int port)
        {
            if (!_isInitialized)
                Start();

            NetManager.Connect("localhost", port, "key");
        }
    }
}
