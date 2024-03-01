using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Branch;

[NotMapped]
public record BranchId(Guid Value);