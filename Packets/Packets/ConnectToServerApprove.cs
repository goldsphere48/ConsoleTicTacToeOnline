using LiteNetLib.Utils;

namespace Packets
{
    public struct ConnectToServerApprove : INetSerializable
    {
        public Guid PlayerID;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(PlayerID.ToString());
        }

        public void Deserialize(NetDataReader reader)
        {
            PlayerID = Guid.Parse(reader.GetString(36));
        }
    }
}
