namespace FitnessTrackingApp.Web.ViewModels.GoalPlan;

public class TrainerGoalPlanViewModel : BaseGoalPlanViewModel
{ 
    public string CustomerName { get; set; } = null!;
    public int WeekCounter { get; set; }
}