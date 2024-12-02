using System.ComponentModel.DataAnnotations;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class AssignWeeklyPanViewModel
{
    public long GoalPlanId { get; set; }

    [Required]
    public int Week { get; set; }
    
    [Required]
    public int TotalDailyCalories => CalculateTotalCalories();

    [Required]
    public int DailyCarbohydrates { get; set; }

    [Required]
    public int DailyProtein { get; set; }

    [Required]
    public int DailyFat { get; set; }

    [Required]
    public int CardioSessionsPerWeek { get; set; }

    public string? CardioType { get; set; }
    public int CaloriesToBurnPerSession { get; set; }
    public string? StrengthTrainingPlan { get; set; }
    
    private int CalculateTotalCalories()
    {
        return (DailyCarbohydrates * CaloriesPerGramOfCarbohydrates) + (DailyProtein * CaloriesPerGramOfProtein) + (DailyFat * CaloriesPerGramOfFat);
    }
}