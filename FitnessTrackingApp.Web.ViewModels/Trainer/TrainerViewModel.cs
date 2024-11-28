using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class TrainerViewModel
{
    public Guid TrainerId { get; set; }
    public string TrainerName { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
    public double AverageRating { get; set; }
    
    [Comment("Used to hide the Trainer from view if the Customer has an Active or Pending Goal Plan")]
    public bool HasGoalPlan { get; set; }
}