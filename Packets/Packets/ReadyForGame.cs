using LiteNetLib.Utils;

namespace Packets
{
    public struct ReadyForGame : INetSerializable
    {
        public Guid RoomID;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(RoomID.ToString());
        }

        public void Deserialize(NetDataReader reader)
        {
            RoomID = Guid.Parse(reader.GetString(36));
        }
    }
}
