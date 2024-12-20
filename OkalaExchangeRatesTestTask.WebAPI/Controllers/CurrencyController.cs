using Microsoft.AspNetCore.Mvc;
using OkalaExchangeRatesTestTask.Domain.Contracts;

namespace OkalaExchangeRatesTestTask.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet("rates/{cryptoCode}")]
    public async Task<IActionResult> GetCurrencyRates(string cryptoCode)
    {
        try
        {
            var rates = await _currencyService.GetCurrencyRatesAsync(cryptoCode);
            return Ok(rates);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
