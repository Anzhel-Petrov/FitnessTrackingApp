namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class GoalPlanDetailsViewModel
{
    public long GoalPlanId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string GoalDescription { get; set; } = null!;
    public decimal CurrentWeight { get; set; } 
    public string CustomerDetails { get; set; } = null!;
    public DateTime? SubmittedOn { get; set; }
}