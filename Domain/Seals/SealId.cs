using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Seal;
[NotMapped]

public record SealId(Guid Value);
