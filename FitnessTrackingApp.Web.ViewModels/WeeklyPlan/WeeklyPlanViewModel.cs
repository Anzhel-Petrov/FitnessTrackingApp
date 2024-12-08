using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class WeeklyPlanViewModel
{
    public long WeeklyPlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int WeekNumber { get; set; }
    public int Carbohydrates { get; set; }
    public int Fat { get; set; }
    public int Protein { get; set; }
    public int TotalDailyCalories { get; set; }
    public int CardioSessionsPerWeek { get; set; }
    public string? CardioType { get; set; }
    public int CaloriesToBurnPerSession { get; set; }
    public bool? IsHIIT { get; set; }
    public decimal Weight { get; set; }

}