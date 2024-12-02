using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
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
        if (string.IsNullOrWhiteSpace(userId))
        {
            return false;
        }
        
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
                HasGoalPlan = userId != Guid.Empty && _dbContext.GoalPlans
                    .Any(gp => gp.UserId == userId && gp.TrainerId == t.Id && (gp.GoalPlanStatus == GoalPlanStatus.Pending || gp.GoalPlanStatus == GoalPlanStatus.Active))
            })
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<Guid> GetTrainerPrimaryKeyAsync(Guid trainerUserId)
    {
        return await _dbContext.Trainers
            .Where(t => t.UserId == trainerUserId)
            .Select(t => t.Id)
            .FirstOrDefaultAsync();
    }
}