namespace FitnessTrackingApp.Common;

public class OperationResult(bool success, string? errorMessage = null)
{
    public bool Success { get; set; } = success;
    public string? ErrorMessage { get; set; } = errorMessage;
}