namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class TrainerWeeklyPlanViewModel
{
    public string CustomerName { get; set; } = null!;

    public ICollection<WeeklyPlanViewModel> WeeklyPlanViewModels { get; set; } =
        new HashSet<WeeklyPlanViewModel>();
}