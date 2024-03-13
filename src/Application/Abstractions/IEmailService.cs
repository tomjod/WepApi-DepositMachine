using Domain.Entities.Users;
using Domain.Entities.Deposits;

namespace Application.Abstractions;

public interface IEmailService
{
    Task SendWelcomeEmailAsync(User user, CancellationToken cancellationToken = default);

    Task SendDepositSuccefullAsync(Deposit deposit, CancellationToken cancellationToken = default);
}
