using Application.Abstractions;
using Domain.Entities.Deposits;
using Domain.Entities.Users;

namespace Infrastructure.Services;

internal sealed class EmailService : IEmailService
{
    public Task SendWelcomeEmailAsync(User user, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;

    public Task SendDepositSuccefullAsync(Deposit deposit, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}
