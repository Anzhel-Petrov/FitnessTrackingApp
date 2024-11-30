using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using FitnessTrackingApp.Web.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Areas.Trainer.Controllers;

[Area("Trainer")]
[MustBeTrainer]
public class GoalPlanController : BaseController
{
    private readonly IGoalPlanService _goalPlanService;

    public GoalPlanController(IGoalPlanService goalPlanService)
    {
        _goalPlanService = goalPlanService;
    }
    
    // Areas/Trainer/Views/GoalPlan/Pending.cshtml
    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var trainerId = this.GetUserId(); 
        var pendingPlans = await _goalPlanService.GetPendingGoalPlansAsync(trainerId);

        return View(pendingPlans); 
    }
}