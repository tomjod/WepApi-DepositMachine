namespace Wep.API.Contracts.Clients;

    public sealed record RegisterClientRequest(
        string RUT,
        string CompanyName,
        string BusinessType,
        string Representative);
    

