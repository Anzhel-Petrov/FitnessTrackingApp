using System.Security.Claims;
using FitnessTrackingApp.Common;
using FitnessTrackingApp.Services.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SelectTrainer(Guid trainerId)
    {
        OperationResult result = await _goalPlanService.AssignTrainerToCustomerAsync(this.GetUserId(), trainerId);

        if (result.Success == false)
        {
            TempData[ErrorMessage] = result.ErrorMessage;
            return RedirectToAction(nameof(AvailableTrainers));
        }

        TempData[SuccessMessage] = TrainerSelectedSuccess;
        return RedirectToAction(nameof(AvailableTrainers));
    }
}