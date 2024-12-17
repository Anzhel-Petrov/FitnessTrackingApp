namespace FitnessTrackingApp.Common;

public static class ErrorMessageConstants
{
    public static string InvalidLogin =>
       "There was an error while logging you in! Please try again later or contact administrator!";
    public static string ErrorAssigningTrainer =>
        "Could not assign the Trainer. Please try again.";
    public static string GoalPlanNotFound =>
        "Goal Plan not found.";
    public static string GoalPlanApprovalIncorrectStatus =>
        "Goal Plan is not in correct status for approval.";
    public static string GoalPlanRejectionIncorrectStatus =>
        "Goal Plan is not in correct status for rejection.";
    public static string RejectReasonEmpty =>
        "Reject reason cannot be empty.";
    public static string WeeklyPlanNotFound =>
        "Invalid or inactive goal plan.";
    public static string WeeklyPlanWeekExists =>
        "A week number for this weekly plan already exists.";
}