using FitnessTrackingApp.Common;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;
using static FitnessTrackingApp.Common.ErrorMessageConstants;


namespace FitnessTrackingApp.Web.Controllers;

public class CustomerController : BaseController
{
    private readonly ITrainerService _trainerService;
    private readonly IGoalPlanService _goalPlanService;
    private readonly IWeeklyPlanService _weeklyPlanService;
    private readonly IBodyWeightService _bodyWeightService;

    public CustomerController(
        ITrainerService trainerService,
        IGoalPlanService goalPlanService,
        IWeeklyPlanService weeklyPlanService,
        IBodyWeightService bodyWeightService)
        : base(trainerService)
    {
        _trainerService = trainerService;
        _goalPlanService = goalPlanService;
        _weeklyPlanService = weeklyPlanService;
        _bodyWeightService = bodyWeightService;
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

        if (model == null)
        {
            //TempData[ErrorMessage] = ActiveGoalPlanNotFound;
            model = new List<WeeklyPlanViewModel>();
        }
            
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> WeeklyPlanDetails(long weeklyPlanId)
    {
        var bodyWeightLogs = await _bodyWeightService.GetBodyWeightLogsViewModelAsync(this.GetUserId(), weeklyPlanId);

        return View(bodyWeightLogs);
    }

    [HttpPost]
    public async Task<IActionResult> AddLog(BodyWeightLogsViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Logs = await _bodyWeightService.GetWeeklyPlanLogsAsync(this.GetUserId(), model.WeeklyPlanId);
            return View(nameof(WeeklyPlanDetails), model);
        }

        OperationResult result = await _bodyWeightService.AddBodyWeightLogAsync(model.NewLog, model.WeeklyPlanId, this.GetUserId());
            
        if (!result.IsSuccess)
        {
            TempData["ErrorMessage"] = result.Message;
            model.Logs = await _bodyWeightService.GetWeeklyPlanLogsAsync(this.GetUserId(), model.WeeklyPlanId);
            return View(nameof(WeeklyPlanDetails), model);
        }
        
        return RedirectToAction(nameof(WeeklyPlanDetails), new { weeklyPlanId = model.WeeklyPlanId });
    }
}