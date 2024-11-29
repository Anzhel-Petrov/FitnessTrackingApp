using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;


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
        
        var userId = this.GetUserId();
        
        if (userId == Guid.Empty)
        {
            return Unauthorized();
        }
        
        var result = await _goalPlanService.CreateGoalPlanAsync(model, userId);
        
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(AvailableTrainers));
        }
        
        TempData[ErrorMessage] = result.Message;
        return View(model);
    }
}