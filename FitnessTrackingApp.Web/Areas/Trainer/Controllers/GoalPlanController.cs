using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models.Enums;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;
using FitnessTrackingApp.Web.ViewModels.GoalPlan;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Areas.Trainer.Controllers;

[Area(TrainerAreaName)]
[Authorize(Roles = TrainerRoleName)]
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
        var activePlans = await _goalPlanService.GetTrainerGoalPlansByStatusAsync(trainerId, GoalPlanStatus.Active);

        return View(activePlans); 
    }
    
    // /Trainer/GoalPlan/Pending
    // Areas/Trainer/Views/GoalPlan/Pending.cshtml
    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var trainerId = await this.GetTrainerId(); 
        var pendingPlans = await _goalPlanService.GetTrainerGoalPlansByStatusAsync(trainerId, GoalPlanStatus.Pending);

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
    
    // /Trainer/GoalPlan/Approve/{goalPlanId}
    [HttpPost]
    public async Task<IActionResult> Approve(long goalPlanId)
    {
        var result = await _goalPlanService.ApproveGoalPlanAsync(goalPlanId);

        if (!result.IsSuccess)
        {
            TempData["Error"] = result.Message;
            return RedirectToAction("Review", new { goalPlanId });
        }
        
        return RedirectToAction("Pending");
    }

    [HttpGet]
    public async Task<IActionResult> Reject(long goalPlanId)
    {
        var goalPlan = await _goalPlanService.FindGoalPlanByIdAsync(goalPlanId);

        if (goalPlan == null)
        {
            return NotFound();
        }

        if (goalPlan.GoalPlanStatus is GoalPlanStatus.Cancelled or GoalPlanStatus.Rejected)
        {
            return BadRequest();
        }

        if (!this.IsTrainer() || goalPlan.TrainerId != await this.GetTrainerId())
        {
            return Unauthorized();
        }

        var viewModel = new RejectGoalPlanViewModel
        {
            GoalPlanId = goalPlan.Id,
        };

        return View(viewModel);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reject(RejectGoalPlanViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var goalPlan = await _goalPlanService.FindGoalPlanByIdAsync(model.GoalPlanId);

        if (goalPlan == null)
        {
            return NotFound();
        }

        if (goalPlan.GoalPlanStatus is GoalPlanStatus.Cancelled or GoalPlanStatus.Rejected)
        {
            return BadRequest();
        }

        if (!this.IsTrainer() || goalPlan.TrainerId != await this.GetTrainerId())
        {
            return Unauthorized();
        }

        var result = await _goalPlanService.RejectGoalPlanAsync(model.GoalPlanId, model.RejectionReason);

        return RedirectToAction(nameof(Pending)); // Redirect to the appropriate Trainer dashboard or list
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