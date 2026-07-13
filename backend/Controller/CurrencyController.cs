using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController(ICurrencyService _currencyService) : ControllerBase
{
 [HttpGet("convert")]
    [Authorize]
    public async Task<IActionResult> Convert(
        [FromQuery] string fromCurrency,
        [FromQuery] string toCurrency,
        [FromQuery] decimal amount)
    {
        var result = await _currencyService.GetExchangeRateAsync(
            fromCurrency,
            toCurrency,
            amount);

        return Ok(new
        {
            fromCurrency,
            toCurrency,
            amount,
            convertedAmount = result
        });
    }
}