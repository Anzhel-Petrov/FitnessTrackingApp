using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.GoalPlan;

namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class OverallProgressViewModel
{
    public decimal MostRecentWeight { get; set; }
    public DateTime MostRecentWeightDate { get; set; }

    public DateTime TargetDate { get; set; }
    public decimal WeeklyProgress { get; set; }
    public decimal MonthlyProgress { get; set; }
    public decimal AllTimeProgress { get; set; }
    
    public decimal BodyWeightGoal { get; set; }
    public BodyWeightGoalCreateViewModel GoalWeightViewModel { get; set; } = null!;
    public IEnumerable<BodyWeightLog>? WeeklyRecords { get; set; }
    public IEnumerable<BodyWeightLog>? MonthlyRecords { get; set; }
    
    public IEnumerable<BodyWeightLogViewModel>? AllLogs { get; set; } = new HashSet<BodyWeightLogViewModel>();
}