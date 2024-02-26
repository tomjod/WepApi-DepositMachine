namespace Domain.Currency;

public class Currency
{
    public CurrencyId Id { get; set; }

    public string CurrencyCode { get; set; } = string.Empty;

    public string CurrencyName { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;
}
