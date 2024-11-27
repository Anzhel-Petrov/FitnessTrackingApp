using System.Security.Claims;
using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;
using static FitnessTrackingApp.Common.ErrorMessageConstants;
using static FitnessTrackingApp.Common.SuccessMessagesConstants;

namespace FitnessTrackingApp.Web.Controllers;

public class CustomerController : BaseController
{
    private readonly ITrainerService _trainerService;
    private readonly IGoalPlanService _goalPlanService;

    public CustomerController(ITrainerService trainerService, IGoalPlanService goalPlanService)
    {
        _trainerService = trainerService;
        _goalPlanService = goalPlanService;
    }

    [HttpGet]
    public async Task<IActionResult> AvailableTrainers()
    {
        var trainers = await _trainerService.GetAvailableTrainersAsync();
        return View(trainers);
    }
    
    [HttpGet]
    public IActionResult SubmitDetails(Guid trainerId)
    {
        var model = new CustomerDetailsInputModel
        {
            TrainerId = trainerId
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitDetails(CustomerDetailsInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Create a new GoalPlan
        var goalPlan = new GoalPlan
        {
            UserId = this.GetUserId(), // Extension method to get the current user's ID
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

        await _goalPlanService.CreateGoalPlanAsync(goalPlan);

        return RedirectToAction("Dashboard", "Customer"); // Redirect to customer dashboard
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> SelectTrainer(Guid trainerId)
    // {
    //     OperationResult result = await _goalPlanService.AssignTrainerToCustomerAsync(this.GetUserId(), trainerId);
    //
    //     if (result.Success == false)
    //     {
    //         TempData[ErrorMessage] = result.ErrorMessage;
    //         return RedirectToAction(nameof(AvailableTrainers));
    //     }
    //
    //     TempData[SuccessMessage] = TrainerSelectedSuccess;
    //     return RedirectToAction(nameof(AvailableTrainers));
    // }
}