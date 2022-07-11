using LiteNetLib.Utils;

namespace Packets
{
    public struct AcceptGame : INetSerializable
    {
        public Guid PlayerId;
        public bool IsAccepted;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(PlayerId.ToString());
            writer.Put(IsAccepted);
        }

        public void Deserialize(NetDataReader reader)
        {
            PlayerId = Guid.Parse(reader.GetString(36));
            IsAccepted = reader.GetBool();
        }
    }
}
