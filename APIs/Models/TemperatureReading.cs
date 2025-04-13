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
        public int entry_key  { get; set; }
        // ID of the Tank
        public int tank_number { get; set; }
        // the recorded temperature
        public double temp { get; set; }
        // the date the temp was recorded 
        public DateTime time_stamp { get; set; }

        //Constructor when date is known
        public TemperatureReading(int tankId, double tankTemp, DateTime recordDate)
        {
            tank_number = tankId;
            temp = tankTemp;
            time_stamp = recordDate;
        }

        //Constructor when date is unknown (Unsure if need yet but added anyway)
        public TemperatureReading(int tankId, double tankTemp)
        {
            tank_number = tankId;
            temp = tankTemp;
            time_stamp = DateTime.Now;
        }

        // empty constructor for entity
        public TemperatureReading(){}
      

        
    }
}
