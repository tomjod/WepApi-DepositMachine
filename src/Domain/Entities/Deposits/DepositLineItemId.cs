using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Deposits;
[NotMapped]

public record DepositLineItemId(Guid Value);