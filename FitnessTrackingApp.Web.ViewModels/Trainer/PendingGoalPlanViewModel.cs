namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class PendingGoalPlanViewModel
{
    public long GoalPlanId { get; set; }
    public string CustomerName { get; set; }
    public string GoalDescription { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Status { get; set; }
}