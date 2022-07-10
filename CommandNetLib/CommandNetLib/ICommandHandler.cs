using LiteNetLib.Utils;

namespace CommandNetLib
{
    public interface ICommandHandler<T> where T : struct, INetSerializable
    {
        public void Handle(T payload);
    }

    public class DefaultHandler<T> : ICommandHandler<T> where T : struct, INetSerializable
    {
        public void Handle(T payload)
        {
            
        }
    }
}
