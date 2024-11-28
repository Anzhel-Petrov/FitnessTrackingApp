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
        var trainers = await _trainerService.GetAvailableTrainersAsync(this.GetUserId());
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
        
        var result = await _goalPlanService.CreateGoalPlanAsync(model, this.GetUserId());
        
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(AvailableTrainers));
        }
        
        ModelState.AddModelError(string.Empty, result.Message!);
        return View(model);
    }
}