using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IBodyWeightService
{
    public Task<BodyWeightGoal?> GetBodyWeightGoalAsync(Guid? userId);
    public Task AddBodyWeightGoal(Guid userId, decimal goalWeight);
    public Task<ICollection<BodyWeightLog>> GetWeeklyBodyWeightLogs(Guid userId);
    public Task<ICollection<BodyWeightLog>> GetMonthlyBodyWeightLogs(Guid userId);
    public Task<ICollection<BodyWeightLog>> GetAllBodyWeightLogs(Guid userId);
}