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
            .FirstOrDefaultAsync(gp => gp.Id == model.GoalPlanId && gp.GoalPlanStatus == GoalPlanStatus.Active && gp.TrainerId == trainerId);

        if (goalPlan == null)
        {
            return new OperationResult(false, "Invalid or inactive goal plan.");
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

    public Task<IEnumerable<WeeklyPlanViewModel>> GetTrainerWeeklyPlansAsync(Guid trainerId)
    {
        throw new NotImplementedException();
    }
}