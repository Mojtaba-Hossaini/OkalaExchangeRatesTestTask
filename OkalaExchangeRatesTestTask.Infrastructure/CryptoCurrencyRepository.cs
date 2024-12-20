using Microsoft.Extensions.Logging;
using OkalaExchangeRatesTestTask.Domain.Contracts;
using OkalaExchangeRatesTestTask.Domain.Dtos;
using OkalaExchangeRatesTestTask.Domain.Entities;

namespace OkalaExchangeRatesTestTask.Infrastructure;

public class CryptoCurrencyRepository : ICryptoCurrencyRepository
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CryptoCurrencyRepository> _logger;

    public CryptoCurrencyRepository(HttpClient httpClient, ILogger<CryptoCurrencyRepository> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<CryptoCurrency> GetCryptoCurrency(string code)
    {
        _logger.LogInformation("Fetching crypto data for {CryptoCode} from API", code);

        var response = await _httpClient.GetStringAsync($"https://api.coinmarketcap.com/v1/cryptocurrency/listings/latest?symbol={code}");

        var data = JsonConvert.DeserializeObject<CryptoCurrencyResponse>(response);

        _logger.LogInformation("Received data: {CryptoCode} with price {PriceInUSD} USD", code, data.PriceInUSD);

        return new CryptoCurrency(code, data.PriceInUSD);
    }
}
