using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IBodyWeightService
{
    public Task<BodyWeightGoal?> GetBodyWeightGoalAsync(Guid userId);
    public Task AddBodyWeightGoal(Guid userId, decimal goalWeight);
    public Task<IEnumerable<BodyWeightLog>> GetWeeklyBodyWeightLogs(Guid userId);
    public Task<IEnumerable<BodyWeightLog>> GetMonthlyBodyWeightLogs(Guid userId);
    public Task<BodyWeightLogsViewModel> GetAllBodyWeightLogs(Guid userId);
    public Task AddLogAsync(BodyWeightLogViewModel logViewModel, Guid userId);
    public Task DeleteLogAsync(long logId, Guid userId);
}