using Microsoft.Extensions.Options;
using OkalaExchangeRatesTestTask.Application.Models;
using OkalaExchangeRatesTestTask.Application.Settings;
using OkalaExchangeRatesTestTask.Domain.Contracts;
using System.Text.Json;

namespace OkalaExchangeRatesTestTask.Application.Services;

public class CurrencyApiService : ICurrencyApiService
{
    private readonly HttpClient _httpClient;
    private readonly CurrencyApiSettings _currencyApiSettings;

    public CurrencyApiService(IOptions<CurrencyApiSettings> options, HttpClient httpClient)
    {
        _currencyApiSettings = options.Value;
        _httpClient = httpClient;
    }

    public async Task<Dictionary<string, decimal>> GetCurrencyExchangeRatesAsync()
    {
        var response = await _httpClient.GetStringAsync($"{_currencyApiSettings.BaseUrl}?access_key={_currencyApiSettings.ApiKey}");
        var result = JsonSerializer.Deserialize<CurrencyExchangeRatesResponse>(response);
        return result?.Rates;
    }
}