using Microsoft.AspNetCore.Mvc;
using Qoniac.WebApi.Services;

namespace Qoniac.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberToWordsConverterController : ControllerBase
    {
        private readonly INumberConversionService _numberConversionService = new NumberConversionService();

        [HttpPost]
        [Route("ConvertToWords")]
        public async Task<string> Post([FromBody]double value)
        {
            var result = await _numberConversionService.GetConvertedNumber(value);

            return result;
        }
    }
}
