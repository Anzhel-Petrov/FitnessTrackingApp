namespace FitnessTrackingApp.Web.ViewModels.GoalPlan;

public abstract class BaseGoalPlanViewModel
{
    public long GoalPlanId { get; set; }
    public string GoalDescription { get; set; } = null!;
    public string CreatedOn { get; set; } = null!;
    public string Status { get; set; } = null!;

}