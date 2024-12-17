using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;
using static FitnessTrackingApp.Common.ErrorMessageConstants;

namespace FitnessTrackingApp.Services.Data;

public class WeeklyPlanService : IWeeklyPlanService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public WeeklyPlanService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WeeklyPlan?> GetWeeklyPlanByIdAsync(long weeklyPlanId)
    {
        return await _dbContext.WeeklyPlans
            .Include(wp => wp.GoalPlan)
            .AsNoTracking()
            .FirstOrDefaultAsync(wp => wp.Id == weeklyPlanId);
    }

    public async Task<OperationResult> AssignWeeklyPlanAsync(AssignWeeklyPanViewModel model, Guid trainerId)
    {
        var goalPlan = await _dbContext.GoalPlans
            .Include(goalPlan => goalPlan.WeeklyPlans)
            .FirstOrDefaultAsync(gp => gp.Id == model.GoalPlanId && gp.GoalPlanStatus == GoalPlanStatus.Active && gp.TrainerId == trainerId);

        if (goalPlan == null)
        {
            return new OperationResult(false, WeeklyPlanNotFound);
        }

        if (goalPlan.WeeklyPlans.Any(wp => wp.Week == model.Week))
        {
            return new OperationResult(false, WeeklyPlanWeekExists);
        }
        
        var weeklyPlan = new WeeklyPlan
        {
            GoalPlanId = model.GoalPlanId,
            Week = model.Week,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            CardioSession = new CardioSession()
            {
                SessionsPerWeek = model.CardioSessionsPerWeek,
                Calories = model.CaloriesToBurnPerSession,
                IsHIIT = model.IsHIIT
            },
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
                        StartDate = bwp.StartDate,
                        EndDate = bwp.EndDate,
                        Carbohydrates = bwp.Macro.DailyCarbohydrates,
                        Fat = bwp.Macro.DailyFat,
                        Protein = bwp.Macro.DailyProtein,
                        TotalDailyCalories = bwp.Macro.TotalDailyCalories,
                        CardioSessionsPerWeek = bwp.CardioSession != null ? bwp.CardioSession.SessionsPerWeek : 0,
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
    
    public async Task<WeeklyPlanIndexViewModel> GetAllWeeklyPlansForCustomerAsync(Guid customerId, int currentPage)
    {
        GoalPlan? activeGoalPlan = await _dbContext.GoalPlans
            .FirstOrDefaultAsync(gp => gp.UserId == customerId && gp.GoalPlanStatus == GoalPlanStatus.Active);

        if (activeGoalPlan == null)
        {
            return null;
        }
        
        var allWeeklyPlans = await _dbContext.WeeklyPlans
            .Where(wp => wp.GoalPlanId == activeGoalPlan.Id)
            .OrderBy(wp => wp.Week)
            .Select(wp => new WeeklyPlanViewModel()
            {
                WeeklyPlanId = wp.Id,
                StartDate = wp.StartDate,
                EndDate = wp.EndDate,
                WeekNumber = wp.Week,
                Carbohydrates = wp.Macro.DailyCarbohydrates,
                Fat = wp.Macro.DailyFat,
                Protein = wp.Macro.DailyProtein,
                TotalDailyCalories = wp.Macro.TotalDailyCalories,
                CardioSessionsPerWeek = wp.CardioSession != null ? wp.CardioSession.SessionsPerWeek : 0,
                CardioType = wp.CardioSession != null ? wp.CardioSession.IsHIIT ? "HIIT" : "Steady-State" : "",
                CaloriesToBurnPerSession = wp.CardioSession != null ? wp.CardioSession.Calories : 0,
                IsHIIT = wp.CardioSession != null && wp.CardioSession.IsHIIT,

                Weight = wp.BodyWeightLogs
                    .OrderByDescending(bwl => bwl.DateLogged)
                    .Select(bwl => bwl.CurrentWeight)
                    .FirstOrDefault()
            })
            .ToListAsync();

        WeeklyPlanIndexViewModel weeklyPlanIndexViewModel = new WeeklyPlanIndexViewModel();

        weeklyPlanIndexViewModel.TotalPages = (int)Math.Ceiling(allWeeklyPlans.Count() / (double)weeklyPlanIndexViewModel.WeeklyPlansPerPage!);

        if (currentPage > weeklyPlanIndexViewModel.TotalPages)
        {
            currentPage = weeklyPlanIndexViewModel.TotalPages;
        }

        weeklyPlanIndexViewModel.CurrentPage = currentPage == 0 ? weeklyPlanIndexViewModel.CurrentPage : currentPage;

        weeklyPlanIndexViewModel.WeeklyPlansAll = allWeeklyPlans;

        weeklyPlanIndexViewModel.WeeklyPlans = allWeeklyPlans.Skip(weeklyPlanIndexViewModel.WeeklyPlansPerPage * (currentPage - 1))
            .Take(PlansPerPage);

        return weeklyPlanIndexViewModel;
    }
}