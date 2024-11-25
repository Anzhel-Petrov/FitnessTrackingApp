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
}