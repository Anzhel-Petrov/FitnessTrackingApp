using System.Runtime.CompilerServices;

namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class TrainerWeeklyPlanViewModel
{
    public string CustomerName { get; set; } = null!;
    public long GoalPlanId { get; set; }
    public int NextWeek { get; set; }
    public ICollection<WeeklyPlanViewModel> WeeklyPlanViewModels { get; set; } =
        new HashSet<WeeklyPlanViewModel>();
}