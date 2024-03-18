namespace Application.Branches.Commands.Create;
public sealed class AddressCommand
{
    public string Address1 { get; set; } = string.Empty;

    public string Address2 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public int PostalCode { get; set; }
}