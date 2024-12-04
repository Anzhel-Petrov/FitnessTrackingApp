namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class BaseGoalPlanViewModel
{
    public long GoalPlanId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string GoalDescription { get; set; } = null!;
    public string CreatedOn { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int WeekCounter { get; set; }
}