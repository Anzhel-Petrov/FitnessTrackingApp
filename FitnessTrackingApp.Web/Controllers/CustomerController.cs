using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;


namespace FitnessTrackingApp.Web.Controllers;

public class CustomerController : BaseController
{
    private readonly ITrainerService _trainerService;
    private readonly IGoalPlanService _goalPlanService;
    private readonly IWeeklyPlanService _weeklyPlanService;

    public CustomerController(
        ITrainerService trainerService,
        IGoalPlanService goalPlanService,
        IWeeklyPlanService weeklyPlanService)
        : base(trainerService)
    {
        _trainerService = trainerService;
        _goalPlanService = goalPlanService;
        _weeklyPlanService = weeklyPlanService;
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
        
        var result = await _goalPlanService.CreateGoalPlanRequestAsync(model, userId);
        
        if (result.IsSuccess)
        {
            return RedirectToAction(nameof(AvailableTrainers));
        }
        
        TempData[ErrorMessage] = result.Message;
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> AllWeeklyPlans()
    {
        var model = await _weeklyPlanService.GetAllWeeklyPlansForCustomerAsync(this.GetUserId());
            
        return View(model);
    }
}