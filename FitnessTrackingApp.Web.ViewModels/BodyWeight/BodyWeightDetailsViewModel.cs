using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Web.ViewModels.BodyWeight;

public class BodyWeightDetailsViewModel
{
    public BodyWeightGoal? BodyWeightGoal { get; set; }
    public BodyWeightGoalCreateViewModel GoalWeightViewModel { get; set; } = null!;
}