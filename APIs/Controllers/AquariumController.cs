using Microsoft.AspNetCore.Mvc;
using AquaInspector.Models;
using System.Reflection;
using AquaInspector.Services;
using System.Threading.Tasks;

namespace AquaInspector.Controllers
{
    [Route("api/tank")]
    [Controller]
    public class AquariumController: ControllerBase
    {
        private readonly ITemperatureService _temperatureService;
        public AquariumController(ITemperatureService temperatureService){
            _temperatureService = temperatureService;
        }

        [HttpPost("temperature-reading")]
        public async Task<IActionResult> PostTemperature([FromBody] TemperatureReading reading)
        {
            try{
                // try and add the temperature to the database 
                ServiceResult result = await _temperatureService.RecordTemperature(reading); 
                //return result
                return StatusCode(result.StatusCode,result.ErrorMessage);
                
            }
          
            //catch general error
            catch(Exception ex){
                return StatusCode(500,ex.Message);
            }
        }
    }
}
