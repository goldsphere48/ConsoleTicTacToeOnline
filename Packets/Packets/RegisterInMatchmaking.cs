using LiteNetLib.Utils;

namespace Packets
{
    public struct RegisterInMatchmaking : INetSerializable
    {
        public Guid Id { get; set; }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id.ToString());
        }

        public void Deserialize(NetDataReader reader)
        {
            Id = Guid.Parse(reader.GetString(36));
        }
    }
}
