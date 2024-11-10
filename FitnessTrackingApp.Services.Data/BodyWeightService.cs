using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class BodyWeightService : IBodyWeightService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public BodyWeightService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<BodyWeightGoal?> GetBodyWeightGoalAsync(Guid userId)
    {
        var bodyWeightGoal = await _dbContext.BodyWeightGoals
            .FirstOrDefaultAsync(g => g.IsActive && g.UserId == userId);

        return bodyWeightGoal;
    }

    public async Task AddBodyWeightGoal(Guid userId, decimal goalWeight)
    {
        var existingWeightGoal = await _dbContext.BodyWeightGoals
            .FirstOrDefaultAsync(g => g.IsActive && g.UserId == userId);

        if (existingWeightGoal != null && existingWeightGoal.IsActive)
        {
            existingWeightGoal.IsActive = false;  // Deactivate the current goal
            _dbContext.BodyWeightGoals.Update(existingWeightGoal);
        }

        BodyWeightGoal newBodyWeightGoal = new BodyWeightGoal()
        {
            UserId = userId,
            GoalWeight = goalWeight,
            IsActive = true,
            DateAdded = DateTime.Today
        };

        _dbContext.BodyWeightGoals.Add(newBodyWeightGoal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<BodyWeightLog>> GetWeeklyBodyWeightLogs(Guid userId)
    {
        var startOfWeek = DateTime.Today.AddDays(-7);
        return await _dbContext.BodyWeightLogs
            .Where(r => r.UserId == userId && r.DateLogged >= startOfWeek)
            .OrderByDescending(r => r.DateLogged)
            .ToListAsync();
    }

    public async Task<ICollection<BodyWeightLog>> GetMonthlyBodyWeightLogs(Guid userId)
    {
        var startOfMonth = DateTime.Today.AddMonths(-1);
        return await _dbContext.BodyWeightLogs
            .Where(r => r.UserId == userId && r.DateLogged >= startOfMonth)
            .OrderByDescending(r => r.DateLogged)
            .ToListAsync();
    }

    public async Task<BodyWeightLogsViewModel> GetAllBodyWeightLogs(Guid userId)
    {
        var bodyWeightLogs = await _dbContext.BodyWeightLogs
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.DateLogged)
            .Select(log => new BodyWeightLogViewModel()
            {
                Id = log.Id,
                UserId = log.UserId,
                LogDate = log.DateLogged,
                Weight = log.CurrentWeight
            })
            .ToListAsync();

        return new BodyWeightLogsViewModel()
        {
            Logs = bodyWeightLogs,
            NewLog = new BodyWeightLogViewModel()
        };
    }

    public async Task AddLogAsync(BodyWeightLogViewModel logViewModel, Guid userId)
    {
        var log = new BodyWeightLog()
        {
            UserId = userId,
            DateLogged = logViewModel.LogDate,
            CurrentWeight = logViewModel.Weight
        };

        await _dbContext.BodyWeightLogs.AddAsync(log);
        await _dbContext.SaveChangesAsync();
    }
}