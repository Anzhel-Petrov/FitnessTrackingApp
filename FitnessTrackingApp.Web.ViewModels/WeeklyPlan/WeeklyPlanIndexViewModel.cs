namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class WeeklyPlanIndexViewModel
{
    public IEnumerable<WeeklyPlanViewModel> WeeklyPlans { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}