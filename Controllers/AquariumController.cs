using Microsoft.AspNetCore.Mvc;
using AquaInspector.Models;

namespace AquaInspector.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class AquariumController : ControllerBase
    {
        [HttpPost("temperature")]
        public IActionResult PostTemperature([FromBody] TemperatureReading reading)
        {
            // Process and store temperature data
            return Ok();
        }
    }
}
