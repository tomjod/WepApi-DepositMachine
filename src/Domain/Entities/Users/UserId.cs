using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Users;

[NotMapped]
public record UserId(Guid Value);
