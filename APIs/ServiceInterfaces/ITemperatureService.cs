using AquaInspector.Models;

namespace AquaInspector.Services;

public interface ITemperatureService{
    public Task<ServiceResult>RecordTemperature(TemperatureReading temperatureReading);
}