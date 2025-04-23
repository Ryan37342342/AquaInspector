using AquaInspector.Models;
using AquaInspector.Data;
using System.Reflection;

namespace AquaInspector.Services;

/// <summary>
/// A service class to handle the logging messages sent by the microcontroller 
/// </summary>
public class LoggingService : ILoggingService {
    private AdminDbWorker _DbWorker;

    public LoggingService(AdminDbWorker adminDbWorker){
        _DbWorker = adminDbWorker;
    }

# region Database operations
  public async Task<ServiceResult> RecordLoggingMessage(LoggingMessage loggingMessage){
            try{
                 //Logging start
                ServiceResult result = new ServiceResult();
                Console.Out.WriteLine("--------------------------------------------");
                Console.Out.WriteLine("Incoming Logging Message....");
                
                if (loggingMessage == null)
                {
                    result.ErrorMessage = "loggingMessage is null";
                    result.StatusCode = 400;
                    result.SuccessResult = false;
                    return result;
                }

                // for each property in the temperature object 
                foreach(PropertyInfo property in typeof(LoggingMessage).GetProperties()){
                    // get the value of the current property from the reading object
                    // if its null
                    object? value = property.GetValue(loggingMessage);
                    Console.Out.WriteLine($"{property.Name}:{value}");
                    // check for any missing values 
                    if (value == null){
                        // return a bad request if any property is missing
                       result.ErrorMessage = $"Property:{property.Name} is empty";
                       result.StatusCode = 500;
                       result.SuccessResult = false;
                       return result;
                        
                    } 
                }
                Console.Out.WriteLine("--------------------------------------------");
        
            // enforce utc format for time
            loggingMessage.time_stamp = DateTime.UtcNow;
            // add the temperature reading to the temperature_readings table in the db
            _DbWorker.logging_messages.Add(loggingMessage);
            // save the changes to the database
            await _DbWorker.SaveChangesAsync();
            // construct a success response
            result.SuccessResult=true;
            result.StatusCode=200;
            result.ErrorMessage="successfully added reading to db";
            return result;
            }

            catch(Exception ex){
                ServiceResult result = new ServiceResult();
                result.ErrorMessage = ex.Message;
                result.StatusCode = 500;
                result.SuccessResult = false;
                return result;
            }
        
           
        }
# endregion
}