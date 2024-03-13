using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DepositMachines;
[NotMapped]

public record DepositMachineId(Guid Value);