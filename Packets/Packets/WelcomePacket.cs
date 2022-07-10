using LiteNetLib.Utils;

namespace Packets
{
    public struct WelcomePacket : INetSerializable
    {
        public string Message;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Message);
        }

        public void Deserialize(NetDataReader reader)
        {
            Message = reader.GetString(256);
        }
    }
}