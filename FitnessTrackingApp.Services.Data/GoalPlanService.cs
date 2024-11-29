using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
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
            if (existingGoalPlan.IsActive) 
                return new OperationResult(false, "An active Goal Plan with this Trainer already exists.");
            if (existingGoalPlan.Status == "Pending")
                return new OperationResult(false, "A pending Goal Plan request for Trainer already exists.");
        }
        
        var goalPlan = new GoalPlan
        {
            UserId = userId,
            TrainerId = model.TrainerId,
            GoalName = model.GoalDescription,
            StartDate = DateTime.UtcNow,
            IsActive = false, // Pending approval
            Status = "Pending",
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
}