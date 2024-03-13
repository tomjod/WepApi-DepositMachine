namespace Application.Branches.Commands.Create;
public sealed record AddressCommand
{
    public string Address1 { get; private set; } = string.Empty;

    public string Address2 { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string State { get; private set; } = string.Empty;

    public string Country { get; private set; } = string.Empty;

    public int PostalCode { get; private set; }
}