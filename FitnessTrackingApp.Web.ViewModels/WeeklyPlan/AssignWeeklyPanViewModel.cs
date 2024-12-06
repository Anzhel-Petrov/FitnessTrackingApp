using System.ComponentModel.DataAnnotations;
using static FitnessTrackingApp.Common.EntityValidationMessages;
using static FitnessTrackingApp.Common.EntityValidationConstant;

namespace FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

public class AssignWeeklyPanViewModel
{
    public long GoalPlanId { get; set; }

    [Required(ErrorMessage = WeekRequired)]
    [Range(MinWeekRange, MaxWeekRange, ErrorMessage = WeekPlanWeekRange)]
    public int Week { get; set; }

    [Required]
    [Range(MinMacroRange, MaxMacroRange, ErrorMessage = MacroRange)]
    public int DailyCarbohydrates { get; set; }

    [Required]
    [Range(MinMacroRange, MaxMacroRange, ErrorMessage = MacroRange)]
    public int DailyProtein { get; set; }

    [Required]
    [Range(MinMacroRange, MaxMacroRange, ErrorMessage = MacroRange)]
    public int DailyFat { get; set; }

    [Required]
    public int CardioSessionsPerWeek { get; set; }

    public string? CardioType { get; set; }
    public int CaloriesToBurnPerSession { get; set; }
    public string? StrengthTrainingPlan { get; set; }
}