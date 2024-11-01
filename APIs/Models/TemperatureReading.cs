namespace AquaInspector.Models
{
    /// <summary>
    /// A model class to hold the temperate of the fish tank 
    /// </summary>
    public class TemperatureReading
    {
        // ID of the Tank
        public int TankID { get; set; }
        // the recorded temperature
        public double Temp { get; set; }
        // the date the temp was recorded 
        public DateTime TimeStamp { get; set; }

        
    }
}
