using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetCurrencies()
    {
        // Implementation for getting currencies
        return Ok("working");
    }
}