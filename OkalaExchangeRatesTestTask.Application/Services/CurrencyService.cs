using OkalaExchangeRatesTestTask.Domain.Contracts;
using OkalaExchangeRatesTestTask.Domain.Entities;

namespace OkalaExchangeRatesTestTask.Application.Services;

public class CurrencyService : ICurrencyService
{
    private readonly ICryptoApiService _cryptoApiService;
    private readonly ICurrencyApiService _currencyApiService;

    public CurrencyService(ICryptoApiService cryptoApiService, ICurrencyApiService currencyApiService)
    {
        _cryptoApiService = cryptoApiService;
        _currencyApiService = currencyApiService;
    }

    public async Task<Currency> GetCurrencyRatesAsync(string cryptoCode)
    {
        var cryptoPrice = await _cryptoApiService.GetCryptoPriceAsync(cryptoCode);
        if (cryptoPrice == null)
        {
            throw new Exception("Cryptocurrency not found.");
        }

        var exchangeRates = await _currencyApiService.GetCurrencyExchangeRatesAsync();

        var currency = new Currency
        {
            Symbol = cryptoCode,
            ExchangeRates = new Dictionary<string, decimal>
            {
                { "USD", cryptoPrice.Quote["USD"] },
                { "EUR", exchangeRates["EUR"] * cryptoPrice.Quote["USD"] },
                { "BRL", exchangeRates["BRL"] * cryptoPrice.Quote["USD"] },
                { "GBP", exchangeRates["GBP"] * cryptoPrice.Quote["USD"] },
                { "AUD", exchangeRates["AUD"] * cryptoPrice.Quote["USD"] }
            }
        };

        return currency;
    }
}