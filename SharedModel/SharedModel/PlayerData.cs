using LiteNetLib.Utils;

namespace SharedModel
{
    public struct PlayerData : INetSerializable
    {
        public Guid Id { get; set; }
        public PlayerType Type { get; set; }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Id.ToString());
            writer.Put((int)Type);
        }

        public void Deserialize(NetDataReader reader)
        {
            Id = Guid.Parse(reader.GetString(36));
            Type = (PlayerType)reader.GetInt();
        }
    }
}
