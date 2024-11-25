namespace FitnessTrackingApp.Web.ViewModels.Trainer;

public class TrainerViewModel
{
    public Guid TrainerId { get; set; }
    public string TrainerName { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
    public double AverageRating { get; set; }
}