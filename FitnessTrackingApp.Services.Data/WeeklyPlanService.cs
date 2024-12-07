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

    public async Task<TrainerWeeklyPlanViewModel?> GetWeeklyPlansByGoalPlanIdAsync(long goalPlanId)
    {
        var goalPlan = await _dbContext.GoalPlans
            .Include(gp => gp.WeeklyPlans)
            .Include(goalPlan => goalPlan.ApplicationUser)
            .FirstOrDefaultAsync(gp => gp.Id == goalPlanId);

        if (goalPlan is null)
        {
            return null;
        }
        
        if (!goalPlan.WeeklyPlans.Any())
        {
            return new TrainerWeeklyPlanViewModel
            {
                CustomerName = goalPlan.ApplicationUser?.UserName ?? string.Empty,
                GoalPlanId = goalPlanId,
                NextWeek = 1,
                WeeklyPlanViewModels = Array.Empty<WeeklyPlanViewModel>()
            };
        }
        
        return await _dbContext.WeeklyPlans
            .Where(wp => wp.GoalPlanId == goalPlanId)
            .OrderBy(wp => wp.Week)
            .Select(wp => new TrainerWeeklyPlanViewModel
            {
                CustomerName = wp.GoalPlan.ApplicationUser.UserName ?? string.Empty,
                GoalPlanId = goalPlanId,
                NextWeek = wp.GoalPlan.WeeklyPlans.Count != 0 ? wp.GoalPlan.WeeklyPlans.Max(w => w.Week) + 1 : 1,
                WeeklyPlanViewModels = wp.GoalPlan.WeeklyPlans.Select(bwp => new WeeklyPlanViewModel()
                    {
                        WeekNumber = bwp.Week,
                        Carbohydrates = bwp.Macro.DailyCarbohydrates,
                        Fat = bwp.Macro.DailyFat,
                        Protein = bwp.Macro.DailyProtein,
                        TotalDailyCalories = bwp.Macro.TotalDailyCalories,
                        CardioSessions = bwp.CardioSession != null ? bwp.CardioSession.SessionsPerWeek : 0,
                        CardioType = bwp.CardioSession != null ? bwp.CardioSession.IsHIIT ? "HIIT" : "Steady-State" : "",
                        IsHIIT = bwp.CardioSession != null && bwp.CardioSession.IsHIIT,

                        Weight = bwp.BodyWeightLogs
                            .OrderByDescending(bwl => bwl.DateLogged)
                            .Select(bwl => bwl.CurrentWeight)
                            .FirstOrDefault()
                    })
                    .ToList()
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<WeeklyPlanViewModel>?> GetAllWeeklyPlansForCustomerAsync(Guid customerId)
    {
        GoalPlan? activeGoalPlan = await _dbContext.GoalPlans
            .FirstOrDefaultAsync(gp => gp.UserId == customerId && gp.GoalPlanStatus == GoalPlanStatus.Active);

        if (activeGoalPlan == null)
        {
            return null;
        }
        
        return await _dbContext.WeeklyPlans
            .Where(wp => wp.GoalPlanId == activeGoalPlan.Id)
            .OrderBy(wp => wp.Week)
            .Select(wp => new WeeklyPlanViewModel()
            {
                WeeklyPlanId = wp.Id,
                WeekNumber = wp.Week,
                Carbohydrates = wp.Macro.DailyCarbohydrates,
                Fat = wp.Macro.DailyFat,
                Protein = wp.Macro.DailyProtein,
                TotalDailyCalories = wp.Macro.TotalDailyCalories,
                CardioSessions = wp.CardioSession != null ? wp.CardioSession.SessionsPerWeek : 0,
                CardioType = wp.CardioSession != null ? wp.CardioSession.IsHIIT ? "HIIT" : "Steady-State" : "",
                IsHIIT = wp.CardioSession != null && wp.CardioSession.IsHIIT,

                Weight = wp.BodyWeightLogs
                    .OrderByDescending(bwl => bwl.DateLogged)
                    .Select(bwl => bwl.CurrentWeight)
                    .FirstOrDefault()
            })
            .ToListAsync();
    }
}