using LiteNetLib.Utils;

namespace Packets
{
    public struct ConnectToServerApprove : INetSerializable
    {
        public int PlayerID;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(PlayerID);
        }

        public void Deserialize(NetDataReader reader)
        {
            PlayerID = reader.GetInt();
        }
    }
}
