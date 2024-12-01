using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.Trainer;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class GoalPlanService : IGoalPlanService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public GoalPlanService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<OperationResult> CreateGoalPlanAsync(CustomerDetailsInputModel model, Guid userId)
    {
        var existingGoalPlan = await _dbContext.GoalPlans
            .Where(gp => gp.TrainerId == model.TrainerId && gp.UserId == userId)
            .FirstOrDefaultAsync();

        if (existingGoalPlan != null)
        {
            if (existingGoalPlan.GoalPlanStatus == GoalPlanStatus.Active) 
                return new OperationResult(false, "An active Goal Plan with this Trainer already exists.");
            if (existingGoalPlan.GoalPlanStatus == GoalPlanStatus.Pending)
                return new OperationResult(false, "A pending Goal Plan request for Trainer already exists.");
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
            return new OperationResult(true, "Goal Plan created successfully.");
        }
        catch (Exception ex)
        {
            return new OperationResult(false, $"An error occurred while adding the log. Error: {ex.Message}");
        }
    }

    public async Task<IEnumerable<PendingGoalPlanViewModel>> GetPendingGoalPlansAsync(Guid trainerId)
    {
        var trainerPrimaryKey = await _dbContext.Trainers
            .Where(t => t.UserId == trainerId)
            .Select(t => t.Id)
            .FirstOrDefaultAsync();
        
        return await _dbContext.GoalPlans
            .Where(gp => gp.TrainerId == trainerPrimaryKey && gp.GoalPlanStatus == GoalPlanStatus.Pending)
            .Select(gp => new PendingGoalPlanViewModel
            {
                GoalPlanId = gp.Id,
                CustomerName = gp.ApplicationUser.UserName ?? string.Empty,
                GoalDescription = gp.CustomerDetails.GoalDescription,
                CreatedOn = gp.CustomerDetails.DateCreated,
                Status = gp.GoalPlanStatus.ToString()
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
            return new OperationResult(false, "Goal Plan not found.");
        }

        goalPlan.GoalPlanStatus = approve ? GoalPlanStatus.Active : GoalPlanStatus.Rejected;
        goalPlan.StartDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new OperationResult(true, approve ? "Goal Plan approved successfully!" : "Goal Plan rejected.");
    }
}