using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class WeeklyPlanService : IWeeklyPlanService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public WeeklyPlanService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<OperationResult> AssignWeeklyPlanAsync(AssignWeeklyPanViewModel model, Guid trainerId)
    {
        var goalPlan = await _dbContext.GoalPlans
            .Include(goalPlan => goalPlan.WeeklyPlans)
            .FirstOrDefaultAsync(gp => gp.Id == model.GoalPlanId && gp.GoalPlanStatus == GoalPlanStatus.Active && gp.TrainerId == trainerId);

        if (goalPlan == null)
        {
            return new OperationResult(false, "Invalid or inactive goal plan.");
        }

        if (goalPlan.WeeklyPlans.Any(wp => wp.Week == model.Week))
        {
            return new OperationResult(false, "A week number for this weekly plan already exists.");
        }
        
        var weeklyPlan = new WeeklyPlan
        {
            GoalPlanId = model.GoalPlanId,
            Week = model.Week,
            Macro = new Macro()
            {
                DailyCarbohydrates = model.DailyCarbohydrates,
                DailyFat = model.DailyFat,
                DailyProtein = model.DailyProtein,
            }
        };

        _dbContext.WeeklyPlans.Add(weeklyPlan);
        await _dbContext.SaveChangesAsync();

        return new OperationResult(true, $"Weekly plan for week {weeklyPlan.Week} was added to Goal Plan.");
    }

    public async Task<IEnumerable<WeeklyPlanViewModel>> GetTrainerWeeklyPlansAsync(long planId)
    {
        return await _dbContext.WeeklyPlans
            .Where(wp => wp.GoalPlanId == planId)
            .OrderBy(wp => wp.Week)
            .Select(wp => new WeeklyPlanViewModel
            {
                CustomerName = wp.GoalPlan.ApplicationUser.UserName ?? string.Empty,
                WeekNumber = wp.Week,
                Carbohydrates = wp.Macro.DailyCarbohydrates,
                Fat = wp.Macro.DailyFat,
                Protein = wp.Macro.DailyProtein,
                TotalDailyCalories = wp.Macro.TotalDailyCalories,
                CardioSessions = wp.CardioSession != null ? wp.CardioSession.SessionsPerWeek : 0,
                CardioType = wp.CardioSession != null ? wp.CardioSession.IsHIIT ? "HIIT" : "Steady-State" : "",
                IsHIIT = wp.CardioSession != null && wp.CardioSession.IsHIIT,
                Weight = wp.GoalPlan.BodyWeightLogs
                    .OrderByDescending(bw => bw.DateLogged)
                    .Select(bw => bw.CurrentWeight)
                    .FirstOrDefault()
            })
            .AsNoTracking()
            .ToListAsync();
    }
}