using AutoMapper;
using Microsoft.Extensions.Options;
using OkalaExchangeRatesTestTask.Application.Models;
using OkalaExchangeRatesTestTask.Application.Settings;
using OkalaExchangeRatesTestTask.Domain.Contracts;
using OkalaExchangeRatesTestTask.Domain.Entities;
using System.Text.Json;

namespace OkalaExchangeRatesTestTask.Application.Services;

public class CryptoApiService : ICryptoApiService
{
    private readonly HttpClient _httpClient;
    private readonly CryptoApiSettings _cryptoApiSettings;
    private readonly IMapper _mapper;

    public CryptoApiService(IOptions<CryptoApiSettings> options, HttpClient httpClient, IMapper mapper)
    {
        _cryptoApiSettings = options.Value;
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public async Task<CryptoPrice> GetCryptoPriceAsync(string cryptoCode)
    {
        try
        {
            var url = $"{_cryptoApiSettings.BaseUrl}{cryptoCode}&convert=USD";
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _cryptoApiSettings.ApiKey);
            var response = await _httpClient.GetStringAsync(url);
            

            var result = JsonSerializer.Deserialize<CryptoPriceResponse>(response);

            var cryptoData = result?.Data?.FirstOrDefault();
            if (cryptoData != null) return _mapper.Map<CryptoPrice>(cryptoData);
        }
        catch (Exception ex)
        {

            throw;
        }
        

        return null;
    }
}
