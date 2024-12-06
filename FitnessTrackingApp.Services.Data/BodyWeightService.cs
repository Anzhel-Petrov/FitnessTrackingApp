using FitnessTrackingApp.Common;
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

    public async Task<OperationResult> AddBodyWeightGoalAsync(Guid userId, decimal goalWeight)
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
        var result = await _dbContext.SaveChangesAsync();

        if (result == 0)
        {
            return new OperationResult(false,"Error adding new body weight goal!");
        }
        
        return new OperationResult(true);
    }

    public async Task<IEnumerable<BodyWeightLog>> GetWeeklyBodyWeightLogsAsync(Guid userId)
    {
        var startOfWeek = DateTime.Today.AddDays(-7);
        return await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .Where(log => log.WeeklyPlan.GoalPlan.UserId == userId && log.DateLogged >= startOfWeek)
            .OrderBy(log => log.DateLogged)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<BodyWeightLog>> GetMonthlyBodyWeightLogsAsync(Guid userId)
    {
        var startOfMonth = DateTime.Today.AddMonths(-1);
        return await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .Where(log => log.WeeklyPlan.GoalPlan.UserId == userId && log.DateLogged >= startOfMonth)
            .OrderBy(log => log.DateLogged)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<BodyWeightLogViewModel>> GetAllBodyWeightLogsAsync(Guid userId)
    {
        return await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .Where(log => log.WeeklyPlan.GoalPlan.UserId == userId)
            .OrderByDescending(log => log.DateLogged)
            .Select(log => new BodyWeightLogViewModel()
            {
                Id = log.Id,
                UserId = log.WeeklyPlan.GoalPlan.UserId,
                LogDate = log.DateLogged,
                Weight = log.CurrentWeight
            })
            .ToListAsync();
    }

    public async Task<BodyWeightLog?> GetLastBodyWeightLogAsync(Guid userId)
    {
        return await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .OrderBy(log => log!.DateLogged)
            .LastOrDefaultAsync(log => log.WeeklyPlan.GoalPlan.UserId == userId);
    }

    public async Task<BodyWeightLogsViewModel> GetBodyWeightLogsViewModelAsync(Guid userId)
    {
        var logs = await GetAllBodyWeightLogsAsync(userId);
        return new BodyWeightLogsViewModel
        {
            Logs = logs,
            NewLog = new BodyWeightLogViewModel()
        };
    }

    public async Task<OperationResult> AddBodyWeightLogAsync(BodyWeightLogViewModel logViewModel, Guid userId)
    {
        var existingDateLog = await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .FirstOrDefaultAsync(l => l.WeeklyPlan.GoalPlan.UserId == userId);
        
        if (existingDateLog != null)
        {
            return new OperationResult(false, "A weight is already logged for that date!");
        }

        var log = new BodyWeightLog()
        {
            WeeklyPlanId = existingDateLog!.WeeklyPlanId,
            DateLogged = logViewModel.LogDate,
            CurrentWeight = logViewModel.Weight
        };
        
        try
        {
            _dbContext.BodyWeightLogs.Add(log);
            await _dbContext.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("IX_BodyWeightLogs_DateLogged") == true)
        {
            // Catching unique constraint violation for DateLogged index
            return new OperationResult(false, "A log entry for this date already exists.");
        }
        catch (Exception ex)
        {
            // Catch any other potential exception
            return new OperationResult(false, $"An error occurred while adding the log. Error: {ex.Message}");
        }

        // await _dbContext.BodyWeightLogs.AddAsync(log);
        // var result = await _dbContext.SaveChangesAsync();
        //
        // if (result == 0)
        // {
        //     return new OperationResult(false, "Error adding body weight goal!");
        // }
        //
        // return new OperationResult(true);
    }
    
    public async Task<OperationResult> DeleteBodyWeightLogAsync(long logId, Guid userId)
    {
        BodyWeightLog? log = await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .FirstOrDefaultAsync(l => l.Id == logId && l.WeeklyPlan.GoalPlan.UserId == userId);

        if (log == null)
        {
            return new OperationResult(false, "Log not found or access denied.");
        }
        
        _dbContext.BodyWeightLogs.Remove(log);
        var result = await _dbContext.SaveChangesAsync();
        
        if (result == 0)
        {
            return new OperationResult(false, "Error deleting body weight log!");
        }
        
        return new OperationResult(true);
    }
}