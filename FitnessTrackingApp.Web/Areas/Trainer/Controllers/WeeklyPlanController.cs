using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using FitnessTrackingApp.Web.Infrastructure.Attributes;
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
    
    // /Trainer/WeeklyPlan/Index
    // Areas/Trainer/Views/WeeklyPlan/Index.cshtml
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var trainerId = await this.GetTrainerId();
        var weeklyPlans = await _weeklyPlanService.GetTrainerWeeklyPlansAsync(trainerId);
        return View(weeklyPlans);
    }
}