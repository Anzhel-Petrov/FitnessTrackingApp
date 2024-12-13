using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.GoalPlan;
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

    public async Task<GoalPlan?> FindGoalPlanByIdAsync(long goalPlanId)
    {
        return await _dbContext.GoalPlans.FindAsync(goalPlanId);
    }

    public async Task<OperationResult> ExistsByIdAndStatusAsync(long goalPlanId, GoalPlanStatus? goalPlanStatus)
    {
        bool result;
        if (goalPlanStatus.HasValue)
        {
            result = await _dbContext.GoalPlans
                .Where(gp => gp.GoalPlanStatus == goalPlanStatus)
                .AnyAsync(gp => gp.Id == goalPlanId);
        }
        else
        {
            result = await _dbContext.GoalPlans
                .AnyAsync(gp => gp.Id == goalPlanId);
        }
        
        return result
            ? new OperationResult(true)
            : new OperationResult(false, goalPlanStatus.HasValue ? $"Goal plan invalid or not in {goalPlanStatus} status." : "Goal plan invalid.");
    }

    public async Task<OperationResult> CreateGoalPlanRequestAsync(CustomerDetailsInputModel model, Guid userId)
    {
        var existingGoalPlans = await _dbContext.GoalPlans
            .Where(gp => gp.UserId == userId &&
                         (gp.GoalPlanStatus == GoalPlanStatus.Active || gp.GoalPlanStatus == GoalPlanStatus.Pending))
            .ToListAsync();

        if (existingGoalPlans.Any())
        {
            var activePlanWithTrainer = existingGoalPlans.Any(gp => gp.GoalPlanStatus == GoalPlanStatus.Active && gp.TrainerId == model.TrainerId);
            var activePlan = existingGoalPlans.Any(gp => gp.GoalPlanStatus == GoalPlanStatus.Active);
            var pendingPlanWithTrainer = existingGoalPlans.Any(gp => gp.GoalPlanStatus == GoalPlanStatus.Pending && gp.TrainerId == model.TrainerId);
            var pendingPlan = existingGoalPlans.Any(gp => gp.GoalPlanStatus == GoalPlanStatus.Pending);

            if (activePlanWithTrainer)
                return new OperationResult(false, "An active Goal Plan with this Trainer already exists.");
            if (activePlan)
                return new OperationResult(false, "An active Goal Plan already exists.");
            if (pendingPlanWithTrainer)
                return new OperationResult(false, "A pending Goal Plan request for this Trainer already exists.");
            if (pendingPlan)
                return new OperationResult(false, "A pending Goal Plan request already exists.");
        }

        var goalPlan = new GoalPlan
        {
            UserId = userId,
            TrainerId = model.TrainerId,
            GoalType = model.GoalType,
            GoalWeigh = model.TargetWeight,
            CurrentWeight = model.StartingWeight,
            StartDate = null,
            EndDate = null,
            CustomerDetails = new CustomerDetails
            {
                GoalType = model.GoalType,
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

    public async Task<IEnumerable<TrainerGoalPlanViewModel>> GetTrainerGoalPlansByStatusAsync(Guid trainerId, GoalPlanStatus? goalPlanStatus)
    {
        var allTrainerGoalPlans = await GetAllTrainerGoalPlansByIdAsync(trainerId);

        return allTrainerGoalPlans.Where(gp => gp.Status == goalPlanStatus.ToString());
    }

    public async Task<IEnumerable<TrainerGoalPlanViewModel>> GetAllTrainerGoalPlansByIdAsync(Guid trainerId)
    {
        return await _dbContext.GoalPlans
            .Where(gp => gp.TrainerId == trainerId)
            .Select(gp => new TrainerGoalPlanViewModel
            {
                GoalPlanId = gp.Id,
                GoalType = gp.CustomerDetails.GoalType,
                CreatedOn = gp.CustomerDetails.DateCreated.ToString("dddd, dd MMMM yyyy"),
                Status = gp.GoalPlanStatus.ToString(),
                GoalWeight = gp.GoalWeigh,
                CurrentWeight = gp.CurrentWeight,
                WeekCounter = gp.WeeklyPlans.Count != 0 ? gp.WeeklyPlans.Max(wp => wp.Week) : 0,
                CustomerName = gp.ApplicationUser.UserName ?? string.Empty
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<CustomerGoalPlanViewModel>> GetAllCustomerGoalPlansByIdAsync(Guid userId)
    {
        return await _dbContext.GoalPlans
            .Where(gp => gp.ApplicationUser.Id == userId)
            .Select(gp => new CustomerGoalPlanViewModel()
            {
                GoalPlanId = gp.Id,
                TrainerName = gp.Trainer.User.UserName ?? string.Empty,
                GoalType = gp.CustomerDetails.GoalType,
                CreatedOn = gp.CustomerDetails.DateCreated.ToString("dddd, dd MMMM yyyy"),
                Status = gp.GoalPlanStatus.ToString(),
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
                GoalType = gp.CustomerDetails.GoalType,
                CurrentWeight = gp.CustomerDetails.StartingWeight,
                CustomerDetails = gp.CustomerDetails.AdditionalNotes ?? string.Empty,
                SubmittedOn = DateTime.UtcNow
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task<OperationResult> ApproveGoalPlanAsync(long goalPlanId)
    {
        var goalPlan = await FindGoalPlanByIdAsync(goalPlanId);

        if (goalPlan == null)
        {
            return new OperationResult(false, GoalPlanNotFound);
        }

        goalPlan.GoalPlanStatus =  GoalPlanStatus.Active;
        goalPlan.StartDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new OperationResult(true, GoalPlanApprovedSuccess);
    }

    public async Task<OperationResult> RejectGoalPlanAsync(long goalPlanId, string rejectReason)
    {
        if (string.IsNullOrWhiteSpace(rejectReason))
        {
            return new OperationResult(false, RejectReasonEmpty);
        }

        var goalPlan = await FindGoalPlanByIdAsync(goalPlanId);

        if (goalPlan == null)
        {
            return new OperationResult(false,GoalPlanNotFound);
        }
        
        goalPlan.GoalPlanStatus = GoalPlanStatus.Rejected;
        goalPlan.RejectionReason = rejectReason;
        
        _dbContext.GoalPlans.Update(goalPlan);
        await _dbContext.SaveChangesAsync();

        return new OperationResult(true);
    }

    public async Task<TrainerDashboardViewModel> GetStatisticsInfoAsync(Guid trainerId, GoalPlanStatus? goalPlanStatus)
    {
        var allGoalPlans = (await GetAllTrainerGoalPlansByIdAsync(trainerId)).ToList();
        
        var filteredGoalPlans = goalPlanStatus.HasValue
            ? allGoalPlans.Where(gp => Enum.Parse<GoalPlanStatus>(gp.Status) == goalPlanStatus.Value).ToList()
            : allGoalPlans.ToList();
        
        TrainerDashboardViewModel model = new TrainerDashboardViewModel()
        {
            StatusGoalPlans = filteredGoalPlans,
            TotalGoalPlansCount = allGoalPlans.Count,
            TotalPendingGoalPlansCount = allGoalPlans.Count(gp => Enum.Parse<GoalPlanStatus>(gp.Status) == GoalPlanStatus.Pending),
            TotalActiveGoalPlansCount = allGoalPlans.Count(gp => Enum.Parse<GoalPlanStatus>(gp.Status) == GoalPlanStatus.Active),
            TotalCompletedGoalPlansCount = allGoalPlans.Count(gp => Enum.Parse<GoalPlanStatus>(gp.Status) == GoalPlanStatus.Completed),
            TotalCancelledGoalPlansCount = allGoalPlans.Count(gp => Enum.Parse<GoalPlanStatus>(gp.Status) == GoalPlanStatus.Cancelled),
            TotalRejectedGoalPlansCount = allGoalPlans.Count(gp => Enum.Parse<GoalPlanStatus>(gp.Status) == GoalPlanStatus.Rejected)
        };

        return model;
    }
}