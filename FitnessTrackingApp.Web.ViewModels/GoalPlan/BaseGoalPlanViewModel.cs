using FitnessTrackingApp.Data.Models.Enums;

namespace FitnessTrackingApp.Web.ViewModels.GoalPlan;

public abstract class BaseGoalPlanViewModel
{
    public long GoalPlanId { get; set; }
    public GoalType GoalType { get; set; }
    public string CreatedOn { get; set; } = null!;
    public string Status { get; set; } = null!;
    public decimal GoalWeight { get; set; }
    public decimal CurrentWeight { get; set; }
}