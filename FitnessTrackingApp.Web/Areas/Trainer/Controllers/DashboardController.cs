﻿using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Areas.Trainer.Controllers;

[Area(TrainerAreaName)]
[Authorize(Roles = TrainerRoleName)]
public class DashboardController : BaseController
{
    private readonly IGoalPlanService _goalPlanService;
    
    public DashboardController(IGoalPlanService goalPlanService, ITrainerService trainerService) : base(trainerService)
    {
        _goalPlanService = goalPlanService;
    }
    
    // /Trainer/Dashboard/Details
    // Areas/Trainer/Views/DashBoard/Details.cshtml
    [HttpGet]
    public async Task<IActionResult> Index(GoalPlanStatus? goalPlanStatus)
    {
        var trainerId = await this.GetTrainerId();

        var model = await _goalPlanService.GetStatisticsInfoAsync(trainerId, goalPlanStatus);

        return View(model);
    }
}