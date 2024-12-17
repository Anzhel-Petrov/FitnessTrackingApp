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

    public async Task<IEnumerable<BodyWeightLog>> GetWeeklyBodyWeightLogsAsync(Guid userId)
    {
        var startOfWeek = DateTime.Today.AddDays(-7);
        return await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .Where(log => log.WeeklyPlan.GoalPlan.UserId == userId && log.DateLogged >= startOfWeek && log.DateLogged <= DateTime.Today)
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
            .Where(log => log.WeeklyPlan.GoalPlan.UserId == userId && log.DateLogged >= startOfMonth && log.DateLogged <= DateTime.Today)
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

    public async Task<List<BodyWeightLogViewModel>> GetWeeklyPlanLogsAsync(Guid userId, long weeklyPlanId)
    {
        return await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .Where(log => log.WeeklyPlan.GoalPlan.UserId == userId && log.WeeklyPlanId == weeklyPlanId)
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

    public async Task<BodyWeightLogsViewModel> GetBodyWeightLogsViewModelAsync(Guid userId, long weeklyPlanId)
    {
        var logs = await GetWeeklyPlanLogsAsync(userId, weeklyPlanId);

        return new BodyWeightLogsViewModel
        {
            WeeklyPlanId = weeklyPlanId,
            Logs = logs,
            NewLog = new BodyWeightLogViewModel()
        };
    }

    public async Task<OperationResult> AddBodyWeightLogAsync(BodyWeightLogViewModel logViewModel, long weeklyPlanId, Guid userId)
    {
        var existingDateLog = await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .FirstOrDefaultAsync(l => l.WeeklyPlan.GoalPlan.UserId == userId && l.DateLogged == logViewModel.LogDate);
        
        if (existingDateLog != null)
        {
            return new OperationResult(false, $"A weight is already logged for that date in week {existingDateLog.WeeklyPlan.Week}!");
        }

        var log = new BodyWeightLog()
        {
            WeeklyPlanId = weeklyPlanId,
            DateLogged = logViewModel.LogDate,
            CurrentWeight = logViewModel.Weight
        };
        
        try
        {
            _dbContext.BodyWeightLogs.Add(log);
            await _dbContext.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (Exception ex)
        {
            // Catch any other potential exception
            return new OperationResult(false, $"An error occurred while adding the log. Error: {ex.Message}");
        }
    }
    
    public async Task<OperationResult> DeleteBodyWeightLogAsync(long logId, long weeklyPlanId, Guid userId)
    {
        BodyWeightLog? log = await _dbContext.BodyWeightLogs
            .Include(wp => wp.WeeklyPlan)
            .ThenInclude(gp => gp.GoalPlan)
            .FirstOrDefaultAsync(l => l.Id == logId && l.WeeklyPlan.Id == weeklyPlanId && l.WeeklyPlan.GoalPlan.UserId == userId);

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