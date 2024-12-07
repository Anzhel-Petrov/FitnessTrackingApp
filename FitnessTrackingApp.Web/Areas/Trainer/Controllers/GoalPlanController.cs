﻿using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using FitnessTrackingApp.Web.Infrastructure.Attributes;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Areas.Trainer.Controllers;

[Area("Trainer")]
[MustBeTrainer]
public class GoalPlanController : BaseController
{
    private readonly IGoalPlanService _goalPlanService;
    private readonly IWeeklyPlanService _weeklyPlanService;

    public GoalPlanController(IGoalPlanService goalPlanService, IWeeklyPlanService weeklyPlanService, ITrainerService trainerService)
        : base(trainerService)
    {
        _goalPlanService = goalPlanService;
        _weeklyPlanService = weeklyPlanService;
    }
    
    // /Trainer/GoalPlan/Active
    // Areas/Trainer/Views/GoalPlan/Active.cshtml
    [HttpGet]
    public async Task<IActionResult> Active()
    {
        var trainerId = await this.GetTrainerId();
        var activePlans = await _goalPlanService.GetGoalPlanByStatusAsync(trainerId, GoalPlanStatus.Active);

        return View(activePlans); 
    }
    
    // /Trainer/GoalPlan/Pending
    // Areas/Trainer/Views/GoalPlan/Pending.cshtml
    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var trainerId = await this.GetTrainerId(); 
        var pendingPlans = await _goalPlanService.GetGoalPlanByStatusAsync(trainerId, GoalPlanStatus.Pending);

        return View(pendingPlans); 
    }
    
    // /Trainer/GoalPlan/Review/{goalPlanId}
    // Areas/Trainer/Views/GoalPlan/Review.cshtml
    [HttpGet]
    public async Task<IActionResult> Review(long goalPlanId)
    {
        var goalPlanDetails = await _goalPlanService.GetGoalPlanDetailsAsync(goalPlanId);

        if (goalPlanDetails == null)
        {
            return NotFound("Goal Plan not found.");
        }

        return View(goalPlanDetails);
    }
    
    // /Trainer/GoalPlan/Process/{goalPlanId}
    [HttpPost]
    public async Task<IActionResult> Process(long goalPlanId, bool approve)
    {
        var result = await _goalPlanService.ProcessGoalPlanAsync(goalPlanId, approve);

        if (!result.IsSuccess)
        {
            TempData["Error"] = result.Message;
            return RedirectToAction("Review", new { goalPlanId });
        }
        
        return RedirectToAction("Pending");
    }
    
    // /Trainer/GoalPlan/Assign/{goalPlanId}
    [HttpGet]
    public async Task<IActionResult> AssignWeeklyPlan(long goalPlanId, int nextWeek)
    {
        OperationResult result = await _goalPlanService.ExistsByIdAndStatusAsync(goalPlanId, GoalPlanStatus.Active);
        
        if (!result.IsSuccess)
        {
            TempData["ErrorMessage"] = result.Message;
            return View();
        }
        
        var model = new AssignWeeklyPanViewModel() { GoalPlanId = goalPlanId, Week = nextWeek };
        return View(model);
    }
    
    // /Trainer/GoalPlan/Assign/{goalPlanId}
    [HttpPost]
    public async Task<IActionResult> AssignWeeklyPlan(AssignWeeklyPanViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var trainerId = await this.GetTrainerId();
        var result = await _weeklyPlanService.AssignWeeklyPlanAsync(model, trainerId);

        if (!result.IsSuccess)
        {
            TempData["ErrorMessage"] = result.Message;
            return View(model);
        }

        return RedirectToAction("Details", "WeeklyPlan", new { area = "Trainer" , goalPlanId = model.GoalPlanId});
    }
}