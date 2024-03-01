using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Machine;
[NotMapped]

public record MachineId(Guid Value);