namespace OkalaExchangeRatesTestTask.Domain.Entities;

public class CryptoPrice
{
    public string Symbol { get; set; }
    public Dictionary<string, decimal> Quote { get; set; }
}