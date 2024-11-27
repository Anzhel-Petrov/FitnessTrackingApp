using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class GoalPlanService : IGoalPlanService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public GoalPlanService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<OperationResult> AssignTrainerToCustomerAsync(Guid customerId, Guid trainerId)
    {
        var newGoalPlan = new GoalPlan
        {
            UserId= customerId,
            TrainerId = trainerId,
            GoalName = "Weight Loss",
            StartDate = DateTime.UtcNow,
            IsActive = true
        };
        
        try
        {
            _dbContext.GoalPlans.Add(newGoalPlan);
            await _dbContext.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("IX_GoalPlans_TrainerId_UserId") == true)
        {
            // Catching unique constraint violation for DateLogged index
            return new OperationResult(false, "An active Goal Plan with that trainer exists.");
        }
        catch (Exception ex)
        {
            // Catch any other potential exception
            return new OperationResult(false, $"An error occurred while adding the log. Error: {ex.Message}");
        }
        // var existingGoalPlan = await _dbContext.GoalPlans
        //     .FirstOrDefaultAsync(gp => gp.UserId == customerId && gp.IsActive);
        //
        // if (existingGoalPlan != null)
        // {
        //     existingGoalPlan.TrainerId = trainerId;
        // }
        // else
        // {
        //     var newGoalPlan = new GoalPlan
        //     {
        //         UserId= customerId,
        //         TrainerId = trainerId,
        //         GoalName = "Weight Loss",
        //         StartDate = DateTime.UtcNow,
        //         IsActive = true
        //     };
        //
        //     _dbContext.GoalPlans.Add(newGoalPlan);
        // }
        //
        // return await _dbContext.SaveChangesAsync() > 0;
    }
}