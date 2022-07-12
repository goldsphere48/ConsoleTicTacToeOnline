using LiteNetLib.Utils;

namespace CommandNetLib
{
    public abstract class Command<T> : ICommandBuilder<T> where T : struct, INetSerializable
    {
        private readonly List<ICommandValidator<T>> _validators = new List<ICommandValidator<T>>();

        ICommandBuilder<T> ICommandBuilder<T>.AddValidator(ICommandValidator<T> validator)
        {
            _validators.Add(validator);
            return this;
        }

        public void Handle(Packet<T> packet)
        {
            HandleInternal(packet.Payload);
        }

        private void HandleInternal(T payload)
        {
            foreach (var result in _validators.Select(commandValidator => commandValidator.Validate(payload)))
                if (result.Status == ValidationStatus.Failed)
                    OnFailedValidation(result);

            Handle(payload);
        }

        public abstract void Handle(T payload);

        protected virtual void OnFailedValidation(ValidationResult result)
        {

        }
    }
}
