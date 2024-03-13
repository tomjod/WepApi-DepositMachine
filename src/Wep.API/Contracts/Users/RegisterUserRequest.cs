namespace Wep.API.Contracts.Users;

    public sealed record RegisterUserRequest(
        string firstname,
        string lastname,
        string username,
        string email,
        string password);
    