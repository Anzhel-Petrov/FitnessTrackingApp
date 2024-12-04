using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.Trainer;
using Microsoft.EntityFrameworkCore;
using static FitnessTrackingApp.Common.ErrorMessageConstants;
using static FitnessTrackingApp.Common.SuccessMessagesConstants;

namespace FitnessTrackingApp.Services.Data;

public class GoalPlanService : IGoalPlanService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public GoalPlanService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<OperationResult> CreateGoalPlanRequestAsync(CustomerDetailsInputModel model, Guid userId)
    {
        var existingGoalPlan = await _dbContext.GoalPlans
            .Where(gp => gp.UserId == userId)
            .FirstOrDefaultAsync();

        if (existingGoalPlan != null)
        {
            if(existingGoalPlan.GoalPlanStatus == GoalPlanStatus.Active)
                if (existingGoalPlan.TrainerId == model.TrainerId)
                    return new OperationResult(false, "An active Goal Plan with this Trainer already exists.");
                else
                    return new OperationResult(false, "An active Goal Plan already exists.");
            if(existingGoalPlan.GoalPlanStatus == GoalPlanStatus.Pending)
                if (existingGoalPlan.TrainerId == model.TrainerId)
                    return new OperationResult(false, "A pending Goal Plan request for Trainer already exists.");
                else
                    return new OperationResult(false, "A pending Goal Plan request already exists.");
        }
        
        var goalPlan = new GoalPlan
        {
            UserId = userId,
            TrainerId = model.TrainerId,
            GoalName = model.GoalDescription,
            StartDate = null,
            CustomerDetails = new CustomerDetails
            {
                GoalDescription = model.GoalDescription,
                AdditionalNotes = model.AdditionalNotes,
                StartingWeight = model.StartingWeight,
                TargetWeight = model.TargetWeight,
                DateCreated = DateTime.UtcNow
            }
        };
        
        try
        {
            _dbContext.GoalPlans.Add(goalPlan);
            await _dbContext.SaveChangesAsync();
            return new OperationResult(true, GoalPlanRequestCreatedSuccess);
        }
        catch (Exception ex)
        {
            return new OperationResult(false, $"An error occurred while adding the log. Error: {ex.Message}");
        }
    }

    public async Task<IEnumerable<BaseGoalPlanViewModel>> GetGoalPlanByStatusAsync(Guid trainerId, GoalPlanStatus goalPlanStatus)
    {
        return await _dbContext.GoalPlans
            .Where(gp => gp.TrainerId == trainerId && gp.GoalPlanStatus == goalPlanStatus)
            .Select(gp => new BaseGoalPlanViewModel
            {
                GoalPlanId = gp.Id,
                CustomerName = gp.ApplicationUser.UserName ?? string.Empty,
                GoalDescription = gp.CustomerDetails.GoalDescription,
                CreatedOn = gp.CustomerDetails.DateCreated.ToString("dddd, dd MMMM yyyy"),
                Status = gp.GoalPlanStatus.ToString(),
                WeekCounter = gp.WeeklyPlans.Any() ? gp.WeeklyPlans.Max(wp => wp.Week) : 0
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<GoalPlanDetailsViewModel?> GetGoalPlanDetailsAsync(long goalPlanId)
    {
        return await _dbContext.GoalPlans
            .Where(gp => gp.Id == goalPlanId)
            .Select(gp => new GoalPlanDetailsViewModel
            {
                GoalPlanId = gp.Id,
                CustomerName = gp.ApplicationUser.UserName ?? string.Empty,
                GoalDescription = gp.CustomerDetails.GoalDescription,
                CurrentWeight = gp.CustomerDetails.StartingWeight,
                CustomerDetails = gp.CustomerDetails.AdditionalNotes ?? string.Empty,
                SubmittedOn = DateTime.UtcNow
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task<OperationResult> ProcessGoalPlanAsync(long goalPlanId, bool approve)
    {
        var goalPlan = await _dbContext.GoalPlans.FindAsync(goalPlanId);

        if (goalPlan == null)
        {
            return new OperationResult(false, GoalPlanNotFound);
        }

        goalPlan.GoalPlanStatus = approve ? GoalPlanStatus.Active : GoalPlanStatus.Rejected;
        goalPlan.StartDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new OperationResult(true, approve ? GoalPlanApprovedSuccess : GoalPlanRejectedSuccess);
    }

    public async Task<TrainerDashboardViewModel> GetStatisticsInfoAsync(Guid trainerId)
    {
        TrainerDashboardViewModel model = new TrainerDashboardViewModel();

        model.TotalActiveGoalPlansCount = await _dbContext.GoalPlans
            .CountAsync(gp => gp.TrainerId == trainerId && gp.GoalPlanStatus == GoalPlanStatus.Active);

        model.TotalPendingGoalPlansCount = await _dbContext.GoalPlans
            .CountAsync(gp => gp.TrainerId == trainerId && gp.GoalPlanStatus == GoalPlanStatus.Pending);
        
        model.TotalCompletedGoalPlansCount = await _dbContext.GoalPlans
            .CountAsync(gp => gp.TrainerId == trainerId && gp.GoalPlanStatus == GoalPlanStatus.Completed);
        
        return model;
    }
}