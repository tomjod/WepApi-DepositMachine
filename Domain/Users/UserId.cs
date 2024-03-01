using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.User;

[NotMapped]
public record UserId(Guid Value);
