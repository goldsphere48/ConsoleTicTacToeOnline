using LiteNetLib.Utils;

namespace SharedModel
{
    public struct PlayerData : INetSerializable
    {
        public int Id { get; set; }
        public PlayerType Type { get; set; }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id);
            writer.Put((int)Type);
        }

        public void Deserialize(NetDataReader reader)
        {
            Id = reader.GetInt();
            Type = (PlayerType)reader.GetInt();
        }
    }
}
