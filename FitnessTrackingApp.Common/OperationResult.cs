namespace FitnessTrackingApp.Common;

public class OperationResult(bool success, string? message = null)
{
    public bool IsSuccess { get; set; } = success;
    public string? Message { get; set; } = message;
}