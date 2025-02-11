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

        //Constructor when date is known
        public TemperatureReading(int tankId, double tankTemp, DateTime recordDate)
        {
            tankNumber = tankId;
            temp = tankTemp;
            timeStamp = recordDate;
        }

        //Constructor when date is unknown (Unsure if need yet but added anyway)
        public TemperatureReading(int tankId, double tankTemp)
        {
            tankNumber = tankId;
            temp = tankTemp;
            timeStamp = DateTime.Now;
        }

        // empty constructor for entity
        public TemperatureReading(){}
      

        
    }
}
