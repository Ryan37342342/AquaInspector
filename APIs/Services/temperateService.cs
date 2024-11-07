using AquaInspector.Data;
using AquaInspector.Models;
using System;





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
        public void RecordTemperature(int tankId, double tankTemp){
            // get the current datetime 
            DateTime recordDate = DateTime.Now;
            // create the temperature reading 
            TemperatureReading recordedTemp = new TemperatureReading(tankId,tankTemp,recordDate);
            // add the temperature reading to the database 
            _DbWorker.TemperatureReadings.Add(recordedTemp);
        }

        #endregion

    }
}