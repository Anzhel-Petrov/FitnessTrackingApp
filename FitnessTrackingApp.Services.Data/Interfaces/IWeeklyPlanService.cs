using FitnessTrackingApp.Common;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IWeeklyPlanService
{
    Task<OperationResult> AssignWeeklyPlanAsync(AssignWeeklyPanViewModel model, Guid trainerId);
    Task<TrainerWeeklyPlanViewModel?> GetWeeklyPlansByGoalPlanIdAsync(long goalPlanId);
    Task<IEnumerable<WeeklyPlanViewModel>> GetAllWeeklyPlansForCustomerAsync(Guid customerId);
}