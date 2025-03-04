namespace RentEasy.Domain.Shared;

public sealed record Currency
{
    internal static readonly Currency None = new("");
    
    public static readonly Currency Usd = new("USD");
    
    public static readonly Currency Eur = new("EUR");
    
    public static readonly Currency Brl = new("BRL");
    
    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Eur,
        Brl
    };

    public string Code { get; init; }

    private Currency(string code) => Code = code;

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ??
                throw new ArgumentOutOfRangeException(nameof(code), "The currency code is invalid.");
    }
}
