namespace OkalaExchangeRatesTestTask.Application.Models;

public class CryptoPriceResponse
{
    public int Status { get; set; }
    public List<CryptoPriceData> Data { get; set; }
}

public class CryptoPriceData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public Dictionary<string, CryptoPriceDetails> Quote { get; set; }
}

public class CryptoPriceDetails
{
    public decimal Price { get; set; }
    public decimal Volume24h { get; set; }
    public decimal MarketCap { get; set; }
}
