using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IBodyWeightService
{
    public Task<BodyWeightGoal?> GetBodyWeightGoalAsync(Guid? userId);

    public Task AddBodyWeightGoal(Guid userId, BodyWeightGoal? bodyWeightGoal, decimal goalWeight);
}