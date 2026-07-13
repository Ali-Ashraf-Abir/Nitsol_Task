using System.Text.Json;
using backend.Dtos;
using backend.Services.Interfaces;

namespace backend.Services;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CurrencyService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<decimal> GetExchangeRateAsync(
        string fromCurrency,
        string toCurrency,
        decimal amount)
    {
        var apiKey = _configuration["Currency:Key"];

        var url =
            $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{fromCurrency}/{toCurrency}/{amount}";

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine(json);

        var result = JsonSerializer.Deserialize<CurrencyResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result == null)
            throw new Exception("Invalid currency API response");

        return result.ConversionResult;
    }
}