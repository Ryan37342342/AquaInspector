using AquaInspector.Models;

public interface ILoggingService {
    public Task<ServiceResult> RecordLoggingMessage(LoggingMessage loggingMessage);
}