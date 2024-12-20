namespace OkalaExchangeRatesTestTask.Domain.Contracts;

public interface ICurrencyApiService
{
    Task<Dictionary<string, decimal>> GetCurrencyExchangeRatesAsync();
}
