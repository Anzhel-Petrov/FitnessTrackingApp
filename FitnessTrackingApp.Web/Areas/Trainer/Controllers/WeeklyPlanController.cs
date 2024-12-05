using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using FitnessTrackingApp.Web.Infrastructure.Attributes;
using FitnessTrackingApp.Web.ViewModels.WeeklyPlan;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Areas.Trainer.Controllers;

[Area("Trainer")]
[MustBeTrainer]
public class WeeklyPlanController : BaseController
{
    private readonly IWeeklyPlanService _weeklyPlanService;
    
    public WeeklyPlanController(IWeeklyPlanService weeklyPlanService, ITrainerService trainerService) : base(trainerService)
    {
        _weeklyPlanService = weeklyPlanService;
    }
    
    // /Trainer/WeeklyPlan/Details/{goalPlanId}
    // Areas/Trainer/Views/WeeklyPlan/Details.cshtml
    [HttpGet]
    public async Task<IActionResult> Details(long goalPlanId)
    {
        var weeklyPlans = await _weeklyPlanService.GetWeeklyPlansByGoalPlaIdAsync(goalPlanId);
        
        if (weeklyPlans == null)
        {
            TempData["ErrorMessage"] = "The Goal Plan does not exist.";
            return RedirectToAction("Active", "GoalPlan");
        }

        // if (!weeklyPlans.WeeklyPlanViewModels.Any())
        // {
        //     TempData["ErrorMessage"] = "This Goal Plan does not have weekly plans assigned.";
        // }
        
        return View(weeklyPlans);
    }
}