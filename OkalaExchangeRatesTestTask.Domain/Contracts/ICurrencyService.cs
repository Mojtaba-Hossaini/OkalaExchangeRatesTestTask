using OkalaExchangeRatesTestTask.Domain.Entities;

namespace OkalaExchangeRatesTestTask.Domain.Contracts;

public interface ICurrencyService
{
    Task<Currency> GetCurrencyRatesAsync(string cryptoCode);
}
