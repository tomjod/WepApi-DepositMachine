using Domain.Errors;
using Domain.Primitives;
using SharedKernel;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed class RUT : ValueObject
    {
        public const int MaxLength = 9;

        private RUT(string value) => Value = value;

        public string Value { get; }

        public static Result<RUT> Create(string rut)
        {
            if (rut.Contains(".") || rut.Contains("-"))
            {
                return Result.Failure<RUT>(DomainErrors.RUT.InvalidFormat);
            }

            if (string.IsNullOrWhiteSpace(rut))
            {
                return Result.Failure<RUT>(DomainErrors.RUT.Empty);
            }

            if (rut.Contains('k'))
            {
                rut = rut.ToUpper();
            }

            // Se chequea el resultado obtenido con el digito virificador que proporciono el usuario
            if (!RutValidator.validate(rut))
            {
                return Result.Failure<RUT>(DomainErrors.RUT.RutInvalid);
            }

            // Se crea y se devuelve el userName si todo esta correcto.
            return Result.Success(new RUT(rut));

        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}