using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.Trainer;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IGoalPlanService
{
    Task<OperationResult> CreateGoalPlanRequestAsync(CustomerDetailsInputModel model, Guid userId);
    Task<IEnumerable<BaseGoalPlanViewModel>> GetGoalPlanByStatusAsync(Guid trainerId, GoalPlanStatus goalPlanStatus);
    Task<GoalPlanDetailsViewModel?> GetGoalPlanDetailsAsync(long goalPlanId);
    Task<OperationResult> ProcessGoalPlanAsync(long goalPlanId, bool approve);
    public Task<TrainerDashboardViewModel> GetStatisticsInfoAsync(Guid trainerId);
}