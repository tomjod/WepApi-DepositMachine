using Domain.Errors;
using Domain.Primitives;
using SharedKernel;

namespace Domain.ValueObjects
{
    public sealed class RUN : ValueObject
    {
        public const int MaxLength = 10;

        private RUN(string value) => Value = value;

        public string Value { get; }

        public static Result<RUN> Create(string username)
        {
            if (username.Contains(".") || username.Contains("-"))
            {
                return Result.Failure<RUN>(DomainErrors.UserName.InvalidFormat);
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                return Result.Failure<RUN>(DomainErrors.UserName.Empty);
            }

            if (username.Length > 9 || username.Length < 8) 
            {
                return Result.Failure<RUN>(DomainErrors.UserName.InvalidFormat);
            }

            if (username.Contains('k'))
            {
                username = username.ToUpper();
            }

            // Se chequea el resultado obtenido con el digito virificador que proporciono el usuario
            if (!RutValidator.validate(username))
            {
                return Result.Failure<RUN>(DomainErrors.UserName.RutInvalid);
            }

            // Se crea y se devuelve el userName si todo esta correcto.
            return Result.Success(new RUN(username));

        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
