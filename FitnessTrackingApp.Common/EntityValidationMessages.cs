namespace FitnessTrackingApp.Common;

public class EntityValidationMessages
{
    public const string CustomerDetailsWeight = "Target weight must be between 30 and 300 kg.";
    
    public const string WeekPlanWeekRange = "Week cannot be 0 or negative number.";
    public const string WeekRequired = "Please specify the week for the plan.";
    public const string MacroRange = "Macros range is between 1 and 500.";

    // Customer Details Submit
    public const string GoalPlanRejectionReasonRequired = "Please provide a reason for the rejection.";
    public const string GoalPlanRejectionLength = "The rejection reason must be between 10 and 500 characters.";
    public const string GoalPlanTypeRequired = "You need to choose a goal";
    public const string GoalPlanTrainerIdRequired = "The trainer value is not valid.";
    public const string GoalPlanAdditionalDetailsIdRequired = "Please provide a few details that would help the trainer tailor your goal plan.";
}