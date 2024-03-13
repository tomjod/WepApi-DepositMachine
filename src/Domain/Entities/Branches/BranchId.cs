using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Branches;

[NotMapped]
public record BranchId(Guid Value);