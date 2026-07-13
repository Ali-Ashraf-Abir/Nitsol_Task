namespace backend.Services.Interfaces;

public interface ICurrencyService
{
    Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency, decimal amount);
}