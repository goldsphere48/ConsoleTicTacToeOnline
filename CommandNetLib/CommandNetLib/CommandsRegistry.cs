using LiteNetLib.Utils;

namespace CommandNetLib
{
    public abstract class CommandsRegistry
    {
        private ICommandRegister _register;

        internal void Initialize(ICommandRegister register)
        {
            _register = register;
        }

        protected void Register<T>(Command<T> command) where T : struct, INetSerializable
        {
            _register.RegisterCommand<T>(command);
        }

        public abstract void RegisterCommands();
    }
}
