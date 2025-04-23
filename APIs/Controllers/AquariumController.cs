using Microsoft.AspNetCore.Mvc;
using AquaInspector.Models;
using System.Reflection;
using AquaInspector.Services;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AquaInspector.Controllers
{
    [Route("api/tank")]
    [Controller]
    public class AquariumController: ControllerBase
    {
        private readonly ITemperatureService _temperatureService;
        private readonly ILoggingService _loggingService;
        public AquariumController(ITemperatureService temperatureService, ILoggingService loggingService){
            _temperatureService = temperatureService;
            _loggingService = loggingService;
        }

        [HttpPost("temperature-reading")]
        public async Task<IActionResult> PostTemperature([FromBody] TemperatureReading reading)
        {
            try{
                // try and add the temperature to the database 
                ServiceResult result = await _temperatureService.RecordTemperature(reading); 
                //return result
                Console.Out.WriteLine($"Result:{result.StatusCode};;{result.ErrorMessage}");
                return StatusCode(result.StatusCode,result.ErrorMessage);
                
            }
          
            //catch general error
            catch(Exception ex){
                Console.Out.WriteLine($"Result:500;;{ex.Message};;{ex.StackTrace}");
                return StatusCode(500,ex.Message);
            }
        }


        [HttpPost("log")]
        public async Task <IActionResult> PostLog([FromBody] LoggingMessage loggingMessage){
            try{
                ServiceResult result = await _loggingService.RecordLoggingMessage(loggingMessage);
                 //return result
                Console.Out.WriteLine($"Result:{result.StatusCode};;{result.ErrorMessage}");
                return StatusCode(result.StatusCode,result.ErrorMessage);
            }

            catch(Exception ex){
                Console.Out.WriteLine($"Error in PostLog:{ex.Message};;{ex.StackTrace}");
                return StatusCode(500,ex.Message);
            }
        }

    }
}
