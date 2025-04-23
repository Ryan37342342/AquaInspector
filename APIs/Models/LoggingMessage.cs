using System.ComponentModel.DataAnnotations;

namespace AquaInspector.Models;
/// <summary>
/// A Class to hold the logging messages from the micro controller
/// </summary>
public class LoggingMessage{
    
    [Key]
    public int entry_key {get; set;}
    public string message{ get; set;}
    public int tank_number { get; set;}
    public DateTime time_stamp {get; set;}
    public string message_type {get; set;}

    /// <summary>
    /// Constuctor for logging message 
    /// </summary>
    /// <param name="tank_id">The id of the tank that the message came from</param>
    /// <param name="loggingMessage">The logging message string</param>
    /// <param name="type">The type of logging message</param>
    public LoggingMessage(int tank_id,string loggingMessage,string type){
        message = loggingMessage;
        tank_number = tank_id;
        message_type = type;

    }
    
    // empty constuctor for entity
    public LoggingMessage(){

    }

}