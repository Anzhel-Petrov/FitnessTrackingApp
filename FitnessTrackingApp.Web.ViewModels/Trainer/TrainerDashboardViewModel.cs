namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class TrainerDashboardViewModel
{
    public TrainerDashboardViewModel()
    {
        AllUsers = new List<AllCustomersViewModel>();
    }
    public int TotalActiveGoalPlansCount { get; set; }
    public int TotalPendingGoalPlansCount { get; set; }
    public int TotalCompletedGoalPlansCount { get; set; }
    public int TotalRejectedGoalPlansCount { get; set; }
    public int TotalCancelledGoalPlansCount { get; set; }
    public IEnumerable<AllCustomersViewModel> AllUsers { get; set; }
}