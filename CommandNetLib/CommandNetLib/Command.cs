using LiteNetLib.Utils;

namespace CommandNetLib
{
    public class Command<T> : ICommandBuilder<T> where T : struct, INetSerializable
    {
        private readonly List<ICommandValidator<T>> _validators;
        private ICommandHandler<T> _handler;

        public Command()
        {
            _validators = new List<ICommandValidator<T>>();
            _handler = new DefaultHandler<T>();
        }

        ICommandBuilder<T> ICommandBuilder<T>.AddValidator(ICommandValidator<T> validator)
        {
            _validators.Add(validator);
            return this;
        }

        ICommandBuilder<T> ICommandBuilder<T>.BindHandler(ICommandHandler<T> handler)
        {
            _handler = handler;
            return this;
        }

        public void Handle(Packet<T> packet)
        {
            Handle(packet.Payload);
        } 

        private void Handle(T payload)
        {
            foreach (var result in _validators.Select(commandValidator => commandValidator.Validate(payload)))
                if (result.Status == ValidationStatus.Failed)
                    OnFailedValidation(result);

            _handler.Handle(payload);
        }

        protected virtual void OnFailedValidation(ValidationResult result)
        {

        }
    }
}
