using LiteNetLib.Utils;

namespace CommandNetLib
{
    public interface ICommandBuilder<T> where T : struct, INetSerializable
    {
        ICommandBuilder<T> AddValidator(ICommandValidator<T> validator);
        ICommandBuilder<T> BindHandler(ICommandHandler<T> handler);
    }
    
    public class CommandBuilder<T> where T : struct, INetSerializable
    {
        private readonly Command<T> _command;
        private readonly ICommandBuilder<T> _builder; 

        public CommandBuilder()
        {
            _command = new Command<T>();
            _builder = _command;
        }

        public CommandBuilder<T> AddValidator(ICommandValidator<T> validator)
        {
            if (validator == null) 
                throw new ArgumentNullException(nameof(validator));
            _builder.AddValidator(validator);
            return this;
        }

        public CommandBuilder<T> BindHandler(ICommandHandler<T> handler)
        {
            if (handler == null) 
                throw new ArgumentNullException(nameof(handler));
            _builder.BindHandler(handler);
            return this;
        }

        public Command<T> Build()
        {
            return _command;
        }
    }
}
