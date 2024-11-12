using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class BodyWeightDetailsViewModel
{
    public BodyWeightGoal? BodyWeightGoal { get; set; }
    public BodyWeightGoalCreateViewModel GoalWeightViewModel { get; set; } = null!;
    
    public decimal MostRecentWeight { get; set; }
    public DateTime MostRecentWeightDate { get; set; }
    public decimal TargetWeight { get; set; }
    public DateTime TargetDate { get; set; }
    public decimal WeeklyProgress { get; set; }
    public decimal MonthlyProgress { get; set; }
    public decimal AllTimeProgress { get; set; }
    public IEnumerable<BodyWeightLog>? WeeklyRecords { get; set; }
    public IEnumerable<BodyWeightLog>? MonthlyRecords { get; set; }
}