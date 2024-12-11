using FitnessTrackingApp.Web.ViewModels.GoalPlan;

namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class TrainerDashboardViewModel
{
    public TrainerDashboardViewModel()
    {
        StatusGoalPlans = new List<TrainerGoalPlanViewModel>();
    }
    public int TotalGoalPlansCount { get; set; }
    public int TotalActiveGoalPlansCount { get; set; }
    public int TotalPendingGoalPlansCount { get; set; }
    public int TotalCompletedGoalPlansCount { get; set; }
    public int TotalRejectedGoalPlansCount { get; set; }
    public int TotalCancelledGoalPlansCount { get; set; }
    public List<TrainerGoalPlanViewModel> StatusGoalPlans { get; set; }
}