namespace OkalaExchangeRatesTestTask.Domain.Entities;

public class Currency
{
    public string Symbol { get; set; }
    public Dictionary<string, decimal> ExchangeRates { get; set; } = new Dictionary<string, decimal>();
}
