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

    public async Task<IEnumerable<TrainerViewModel>> GetAvailableTrainersAsync()
    {
        return await _dbContext.Trainers
            .Where(t => t.IsAvailable)
            .OrderByDescending(t => t.AverageRating)
            .Select(t => new TrainerViewModel
            {
                TrainerId = t.Id,
                TrainerName = t.User.UserName!,
                YearsOfExperience = t.YearsOfExperience,
                AverageRating = t.AverageRating
            })
            .ToListAsync();
    }

    public Task<bool> AssignTrainerToCustomerAsync(Guid customerId, Guid trainerId)
    {
        throw new NotImplementedException();
    }
}