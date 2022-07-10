using System.ComponentModel;
using LiteNetLib.Utils;

namespace CommandNetLib
{
    public interface ICommandValidator<T> where T : struct, INetSerializable
    {
        public ValidationResult Validate(T commandData);
    }

    public struct ValidationResult
    {
        public readonly ValidationStatus Status;
        public readonly int Code;

        public ValidationResult(ValidationStatus status, int code)
        {
            Status = status;
            Code = code;
        }

        public static ValidationResult Success => new (ValidationStatus.Success, 0);
        public static ValidationResult Failed(int code) => new (ValidationStatus.Failed, code);
    }

    public enum ValidationStatus
    {
        None,
        Failed,
        Success
    }
}
