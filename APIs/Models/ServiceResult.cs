namespace AquaInspector.Models;

/// <summary>
/// A Class for the service layer result
/// </summary>
public class ServiceResult{
    public int StatusCode {get;set;}
    public bool SuccessResult {get;set;}
    public string ErrorMessage {get;set;}
}