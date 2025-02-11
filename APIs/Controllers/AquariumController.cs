using Microsoft.AspNetCore.Mvc;
using AquaInspector.Models;

namespace AquaInspector.Controllers
{
    [Route("api/tank")]
    [Controller]
    public class AquariumController : ControllerBase
    {
        [HttpPost("temperature-reading")]
        public IActionResult PostTemperature([FromBody] TemperatureReading reading)
        {
            // check reading contains some 
            // Process and store temperature data
            Console.Out.WriteLine("Recieved Temperature reading of {}",reading.temp);
            return Ok();
        }
    }
}
