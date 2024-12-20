using OkalaExchangeRatesTestTask.Domain.Entities;

namespace OkalaExchangeRatesTestTask.Domain.Contracts;

public interface ICryptoApiService
{
    Task<CryptoPrice> GetCryptoPriceAsync(string cryptoCode);
}
