namespace FitnessTrackingApp.Data.Models.Enums;

public enum GoalPlanStatus
{
    Pending = 0,
    Active = 1,
    Rejected = 2, // Rejected by Trainer - Pending -> Rejected
    Completed = 3,
    Cancelled = 4, // Cancelled by Customer
    OnHold = 5
}