using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Deposit;
[NotMapped]

public record DepositLineItemId(Guid Value);