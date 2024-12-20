﻿using FitnessTrackingApp.Common;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis;


namespace FitnessTrackingApp.Web.Controllers;

[Authorize(Roles = CustomerRoleName)]
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

        if (!await _trainerService.TrainerExistsByIdAsync(model.TrainerId.ToString()))
        {
            return BadRequest();
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
    public async Task<IActionResult> AllWeeklyPlans(int currentPage)
    {
        var model = await _weeklyPlanService.GetAllWeeklyPlansForCustomerAsync(this.GetUserId(), currentPage);

        if (model == null)
        {
            //TempData[ErrorMessage] = ActiveGoalPlanNotFound;
            model = new WeeklyPlanIndexViewModel();
        }

        model.GoalWeight = await this._goalPlanService.GetGoalWeightASync(this.GetUserId());

        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> WeeklyPlanDetails(long weeklyPlanId)
    {
        var weeklyPlan = await _weeklyPlanService.GetWeeklyPlanByIdAsync(weeklyPlanId);

        if (weeklyPlan == null)
        {
            return NotFound();
        }

        if (weeklyPlan.GoalPlan.UserId != this.GetUserId())
        {
            return Unauthorized();
        }

        var bodyWeightLogs = await _bodyWeightService.GetBodyWeightLogsViewModelAsync(this.GetUserId(), weeklyPlanId);
        bodyWeightLogs.WeeklyPlanStartDate = weeklyPlan.StartDate;
        bodyWeightLogs.WeeklyPlanEndDate = weeklyPlan.EndDate;

        return View(bodyWeightLogs);
    }

    [HttpPost]
    public async Task<IActionResult> AddLog(BodyWeightLogsViewModel model)
    {
        var weeklyPlan = await _weeklyPlanService.GetWeeklyPlanByIdAsync(model.WeeklyPlanId);

        if (weeklyPlan == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            model.Logs = await _bodyWeightService.GetWeeklyPlanLogsAsync(this.GetUserId(), model.WeeklyPlanId);
            model.WeeklyPlanStartDate = weeklyPlan.StartDate;
            model.WeeklyPlanEndDate = weeklyPlan.EndDate;
            return View(nameof(WeeklyPlanDetails), model);
        }

        OperationResult result = await _bodyWeightService.AddBodyWeightLogAsync(model.NewLog, model.WeeklyPlanId, this.GetUserId());
            
        if (!result.IsSuccess)
        {
            TempData["ErrorMessage"] = result.Message;
        }

        model.Logs = await _bodyWeightService.GetWeeklyPlanLogsAsync(this.GetUserId(), model.WeeklyPlanId);
        model.WeeklyPlanStartDate = weeklyPlan.StartDate;
        model.WeeklyPlanEndDate = weeklyPlan.EndDate;
        return View(nameof(WeeklyPlanDetails), model);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveLog(long logId, long weeklyPlanId)
    {
        OperationResult result = await _bodyWeightService.DeleteBodyWeightLogAsync(logId, weeklyPlanId, this.GetUserId());

        if (result.IsSuccess == false)
        {

        }

        return RedirectToAction(nameof(WeeklyPlanDetails), new { weeklyPlanId = weeklyPlanId});
    }

    [HttpGet]
    public async Task<IActionResult> OverallProgress()
    {
        var currentUserId = this.GetUserId();

        var bodyWeightGoal = await _goalPlanService.GetGoalWeightASync(currentUserId);

        var weeklyBodyWeightProgress = (await _bodyWeightService.GetWeeklyBodyWeightLogsAsync(currentUserId)).ToList();

        var monthlyBodyWeightProgress = (await _bodyWeightService.GetMonthlyBodyWeightLogsAsync(currentUserId)).ToList();

        bool hasStatistics = bodyWeightGoal != 0 || weeklyBodyWeightProgress.Any() || monthlyBodyWeightProgress.Any();

        if (!hasStatistics)
        {
            // Return a view with no statistics
            return View(new BodyWeightDetailsViewModel { HasStatistics = false });
        }

        var lastLoggedBodyWeight = weeklyBodyWeightProgress.Select(l => l.CurrentWeight).LastOrDefault();

        var lastBodyWeightLoggedDate = weeklyBodyWeightProgress.Select(l => l.DateLogged).LastOrDefault();

        var weeklyProgress = weeklyBodyWeightProgress.Select(wp => wp.CurrentWeight).FirstOrDefault() -
                             weeklyBodyWeightProgress.Select(wp => wp.CurrentWeight).LastOrDefault();

        BodyWeightDetailsViewModel bodyWeightDetailsViewModel = new BodyWeightDetailsViewModel()
        {
            HasStatistics = true,
            BodyWeightGoal = bodyWeightGoal,
            MonthlyRecords = monthlyBodyWeightProgress,
            WeeklyRecords = weeklyBodyWeightProgress,
            MostRecentWeight = lastLoggedBodyWeight,
            MostRecentWeightDate = lastBodyWeightLoggedDate,
            WeeklyProgress = weeklyProgress
        };

        return View(bodyWeightDetailsViewModel);
    }
}