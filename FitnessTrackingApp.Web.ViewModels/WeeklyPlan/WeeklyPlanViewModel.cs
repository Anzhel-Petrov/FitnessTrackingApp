namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class WeeklyPlanViewModel
{
    public int WeekNumber { get; set; }
    public int Carbohydrates { get; set; }
    public int Fat { get; set; }
    public int Protein { get; set; }
    public int TotalDailyCalories { get; set; }
    public int CardioSessions { get; set; }
    public string? CardioType { get; set; }
    public double Weight { get; set; }
    public bool IsHIIT { get; set; } 
}