namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class CustomerViewModel
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool HasGoalPlan { get; set; }
    public bool IsAssigned { get; set; }
}