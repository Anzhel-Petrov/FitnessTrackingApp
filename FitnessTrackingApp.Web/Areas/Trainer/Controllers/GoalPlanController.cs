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

    public GoalPlanController(IGoalPlanService goalPlanService, ITrainerService trainerService)
        : base(trainerService)
    {
        _goalPlanService = goalPlanService;
    }
    
    // /Trainer/GoalPlan/Pending
    // Areas/Trainer/Views/GoalPlan/Pending.cshtml
    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var trainerId = this.GetUserId(); 
        var pendingPlans = await _goalPlanService.GetPendingGoalPlansAsync(trainerId);

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
    
    // Trainer/GoalPlan/Process/{goalPlanId}
    [HttpPost]
    public async Task<IActionResult> Process(long goalPlanId, bool approve)
    {
        var result = await _goalPlanService.ProcessGoalPlanAsync(goalPlanId, approve);

        if (!result.IsSuccess)
        {
            TempData["Error"] = result.Message;
            return RedirectToAction("Review", new { goalPlanId });
        }

        TempData["Success"] = approve ? "Goal Plan approved successfully!" : "Goal Plan rejected.";
        return RedirectToAction("Pending");
    }
}