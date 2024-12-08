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

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public int CardioSessionsPerWeek { get; set; }

    public bool IsHIIT { get; set; }
    public int CaloriesToBurnPerSession { get; set; }
    public string? StrengthTrainingPlan { get; set; }
}