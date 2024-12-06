namespace FitnessTrackingApp.Common;

public class EntityValidationMessages
{
    public const string CustomerDetailsWeight = "Target weight must be between 30 and 300 kg.";
    
    public const string WeekPlanWeekRange = "Week cannot be 0 or negative number.";
    public const string WeekRequired = "Please specify the week for the plan.";
    public const string MacroRange = "Macros range is between 1 and 500.";
}