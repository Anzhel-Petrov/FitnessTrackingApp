namespace FitnessTrackingApp.Common;

public static class ApplicationConstants
{
    public const float BodyWeightMinRange = 30f;
    public const float BodyWeightMaxRange = 300f;
    
    // Macros
    public const int CaloriesPerGramOfProtein = 4;
    public const int CaloriesPerGramOfCarbohydrates = 4;
    public const int CaloriesPerGramOfFat = 9;
    
    // GoalPlan
    public const string OnlyOnePendingGoalPlan = "[GoalPlanStatus] = 0";
    public const string OnlyOneActiveGoalPlan = "[GoalPlanStatus] = 1";
    
    // Customer Details
    public const int GoalDescriptionMaxLength = 100;
    public const int AdditionalNotesMaxLength = 1000;

}