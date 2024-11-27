using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IGoalPlanService
{
    Task<OperationResult> CreateGoalPlanAsync(GoalPlan goalPlan);
}