using System.ComponentModel.DataAnnotations;

namespace AquaInspector.Models
{
    /// <summary>
    /// A model class to hold the temperate of the fish tank 
    /// </summary>
    public class TemperatureReading
    {
        [Key]
        // ID of the reading
        public int entryKey  { get; set; }
        // ID of the Tank
        public int tankNumber { get; set; }
        // the recorded temperature
        public double temp { get; set; }
        // the date the temp was recorded 
        public DateTime timeStamp { get; set; }
        public TemperatureReading(int tankId, double tankTemp, DateTime recordDate)
        {
            tankNumber = tankId;
            temp = tankTemp;
            timeStamp = recordDate;
        }

        public TemperatureReading(){}
      

        
    }
}
