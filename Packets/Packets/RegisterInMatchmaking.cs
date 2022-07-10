using LiteNetLib.Utils;

namespace Packets
{
    public struct RegisterInMatchmaking : INetSerializable
    {
        public int Id { get; set; }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
        }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
        }
    }
}
