using LiteNetLib.Utils;
using SharedModel;

namespace Packets
{
    public struct StartGame : INetSerializable
    {
        public PlayerType PlayerType;

        public void Serialize(NetDataWriter writer)
        {
            writer.Put((int)PlayerType);    
        }

        public void Deserialize(NetDataReader reader)
        {
            PlayerType = (PlayerType)reader.GetInt();
        }
    }
}
