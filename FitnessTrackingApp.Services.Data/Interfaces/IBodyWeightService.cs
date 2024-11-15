using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IBodyWeightService
{
    public Task<BodyWeightGoal?> GetBodyWeightGoalAsync(Guid userId);
    public Task<OperationResult> AddBodyWeightGoalAsync(Guid userId, decimal goalWeight);
    public Task<IEnumerable<BodyWeightLog>> GetWeeklyBodyWeightLogsAsync(Guid userId);
    public Task<IEnumerable<BodyWeightLog>> GetMonthlyBodyWeightLogsAsync(Guid userId);
    public Task<List<BodyWeightLogViewModel>> GetAllBodyWeightLogsAsync(Guid userId);
    public Task<BodyWeightLog?> GetLastBodyWeightLogAsync(Guid userId);
    public Task<BodyWeightLogsViewModel> GetBodyWeightLogsViewModelAsync(Guid userId);
    public Task<OperationResult> AddBodyWeightLogAsync(BodyWeightLogViewModel logViewModel, Guid userId);
    public Task<OperationResult> DeleteBodyWeightLogAsync(long logId, Guid userId);
}