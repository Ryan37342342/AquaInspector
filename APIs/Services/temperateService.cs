using AquaInspector.Data;
using AquaInspector.Models;
using Sprache;
using System;
using System.Reflection;





namespace AquaInspector.Services 
{
    /// <summary>
    /// This is a service class to contain all functions and logic related to the temperature data
    /// </summary>
    public class TemperatureService : ITemperatureService{

        // maintain a reference to the DB Context object
        private AdminDbWorker _DbWorker;
        // Constructor
        public TemperatureService(AdminDbWorker worker){
            _DbWorker = worker;
        }


        #region Database operations 

        /// <summary>
        /// A method that takes the measured temperature reading and writes it to the database 
        /// </summary>
        /// <param name="tankId"></param>
        /// <param name="tankTemp"></param>
        public async Task<ServiceResult> RecordTemperature(TemperatureReading temperatureReading){
            try{
                 //Logging start
                ServiceResult result = new ServiceResult();
                Console.Out.WriteLine("--------------------------------------------");
                Console.Out.WriteLine("Incoming Temp Reading....n");
                // for each property in the temperature object 
                foreach(PropertyInfo property in typeof(TemperatureReading).GetProperties()){
                    // get the value of the current property from the reading object
                    // if its null
                    object? value = property.GetValue(temperatureReading);
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
        

            // add the temperature reading to the temperature_readings table in the db
            _DbWorker.temperature_readings.Add(temperatureReading);
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



        #endregion

    }
}