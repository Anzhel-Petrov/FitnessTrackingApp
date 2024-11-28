using FitnessTrackingApp.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Trainer;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class TrainerService : ITrainerService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public TrainerService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> TrainerExistsByUserIdAsync(string userId)
    {
        bool result = await _dbContext
            .Trainers
            .AnyAsync(a => a.UserId.ToString() == userId);

        return result;
    }

    public async Task<IEnumerable<TrainerViewModel>> GetAvailableTrainersAsync(Guid userId)
    {
        return await _dbContext.Trainers
            .Where(t => t.IsAvailable)
            .OrderByDescending(t => t.AverageRating)
            .Select(t => new TrainerViewModel
            {
                TrainerId = t.Id,
                TrainerName = t.User.UserName!,
                YearsOfExperience = t.YearsOfExperience,
                AverageRating = t.AverageRating,
                HasGoalPlan = userId != Guid.Empty && _dbContext.GoalPlans.Any(gp => gp.UserId == userId && gp.TrainerId == t.Id && (gp.Status == "Pending" || gp.Status == "Active"))
            })
            .AsNoTracking()
            .ToListAsync();
    }
}