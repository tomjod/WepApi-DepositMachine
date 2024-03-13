using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Seals;
[NotMapped]

public record SealId(Guid Value);
