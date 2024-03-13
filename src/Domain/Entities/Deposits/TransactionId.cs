using Domain.Errors;
using Domain.Primitives;
using SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Deposits;
[NotMapped]

public sealed class TransactionId : ValueObject
{
    public const int MaxLength = 15;

    private TransactionId(string value)
    {
        Value = value;
    }
    public string Value { get; }
    public static Result<TransactionId> Create(string transactionId)
    {
        if (string.IsNullOrWhiteSpace(transactionId))
        {
            return Result.Failure<TransactionId>(DomainErrors.Transaction.Empty);
        }

        if (transactionId.Length > MaxLength)
        {
            return Result.Failure<TransactionId>(DomainErrors.Transaction.BadFormat);
        }

        return new TransactionId(transactionId);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}