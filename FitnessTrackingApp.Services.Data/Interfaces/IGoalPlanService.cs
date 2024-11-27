using FitnessTrackingApp.Common;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IGoalPlanService
{
    Task<OperationResult> AssignTrainerToCustomerAsync(Guid customerId, Guid trainerId);
}