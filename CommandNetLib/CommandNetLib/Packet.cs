using LiteNetLib.Utils;

namespace CommandNetLib
{
    public struct Packet<T> : INetSerializable where T : struct, INetSerializable
    {
        public readonly Meta Meta;
        public T Payload;

        public Packet(T payload, Meta meta)
        {
            Payload = payload;
            Meta = meta;
        }

        public void Serialize(NetDataWriter writer)
        {
            writer.Put(Payload);
        }

        public void Deserialize(NetDataReader reader)
        {
            Payload = reader.Get<T>();
        }
    }

    public readonly struct Meta
    {
        public readonly int RoomID;
    }
}
