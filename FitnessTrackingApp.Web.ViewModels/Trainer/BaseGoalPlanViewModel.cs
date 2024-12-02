namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class BaseGoalPlanViewModel
{
    public long GoalPlanId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string GoalDescription { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public string Status { get; set; } = null!;
}