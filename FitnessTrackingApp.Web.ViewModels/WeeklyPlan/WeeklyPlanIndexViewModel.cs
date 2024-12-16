using System.Runtime.CompilerServices;
using FitnessTrackingApp.Common;

namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using static GeneralApplicationConstants;

public class WeeklyPlanIndexViewModel
{
    public int WeeklyPlansPerPage { get; set; } = PlansPerPage;
    public int CurrentPage { get; set; } = StartPage;
    public int TotalPages { get; set; }
    public IEnumerable<WeeklyPlanViewModel> WeeklyPlans { get; set; } = new HashSet<WeeklyPlanViewModel>();
}