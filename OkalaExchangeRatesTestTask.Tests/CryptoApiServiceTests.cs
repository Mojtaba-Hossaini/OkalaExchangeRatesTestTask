using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using OkalaExchangeRatesTestTask.Application.Services;
using OkalaExchangeRatesTestTask.Application.Settings;

namespace OkalaExchangeRatesTestTask.Tests;

public class CryptoApiServiceTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CryptoApiService _cryptoApiService;

    public CryptoApiServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);

        _mapperMock = new Mock<IMapper>();

        _cryptoApiService = new CryptoApiService(
    Options.Create(new CryptoApiSettings { BaseUrl = "https://pro-api.coinmarketcap.com/", ApiKey = "943798c5-e82b-46fc-8ef9-ad94c65e5969" }),
    _httpClient,
    _mapperMock.Object
);
    }
}