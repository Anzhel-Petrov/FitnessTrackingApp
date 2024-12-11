using FitnessTrackingApp.Data.Models.Enums;

namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class GoalPlanDetailsViewModel
{
    public long GoalPlanId { get; set; }
    public string CustomerName { get; set; } = null!;
    public GoalType GoalType { get; set; }
    public decimal CurrentWeight { get; set; } 
    public string CustomerDetails { get; set; } = null!;
    public DateTime? SubmittedOn { get; set; }
}