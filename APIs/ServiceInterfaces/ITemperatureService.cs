namespace AquaInspector.Services;

public interface ITemperatureService{
    public void RecordTemperature(int tankId, double tankTemp);
}