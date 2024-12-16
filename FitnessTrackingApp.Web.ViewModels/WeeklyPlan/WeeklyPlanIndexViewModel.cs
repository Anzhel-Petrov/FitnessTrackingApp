namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class WeeklyPlanIndexViewModel
{
    public int WeeklyPlansPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<WeeklyPlanViewModel> WeeklyPlans { get; set; } = new HashSet<WeeklyPlanViewModel>();
}