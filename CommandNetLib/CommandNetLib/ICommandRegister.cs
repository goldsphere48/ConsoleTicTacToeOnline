using LiteNetLib.Utils;

namespace CommandNetLib
{
    internal interface ICommandRegister
    {
        void RegisterCommand<T>(Command<T> command) where T : struct, INetSerializable;
    }
}
