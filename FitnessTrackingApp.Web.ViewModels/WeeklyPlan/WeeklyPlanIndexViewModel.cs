using System.Runtime.CompilerServices;
using FitnessTrackingApp.Common;

namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using static GeneralApplicationConstants;

public class WeeklyPlanIndexViewModel
{
    public int WeeklyPlansPerPage { get; set; } = PlansPerPage;
    public int CurrentPage { get; set; } = StartPage;
    public int TotalPages { get; set; }
    public decimal GoalWeight { get; set; }
    public IEnumerable<WeeklyPlanViewModel> WeeklyPlansAll { get; set; } = new HashSet<WeeklyPlanViewModel>();
    public IEnumerable<WeeklyPlanViewModel> WeeklyPlans { get; set; } = new HashSet<WeeklyPlanViewModel>();
}