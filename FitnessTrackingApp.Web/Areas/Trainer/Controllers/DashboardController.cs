using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using FitnessTrackingApp.Web.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Areas.Trainer.Controllers;

[Area("Trainer")]
[MustBeTrainer]
public class DashboardController : BaseController
{
    private readonly IGoalPlanService _goalPlanService;
    
    public DashboardController(IGoalPlanService goalPlanService, ITrainerService trainerService) : base(trainerService)
    {
        _goalPlanService = goalPlanService;
    }
    
    // /Trainer/Dashboard/Index
    // Areas/Trainer/Views/DashBoard/Index.cshtml
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var trainerId = this.GetUserId();

        var dashBoardViewModel = await _goalPlanService.GetStatisticsInfoAsync(trainerId);

        return View(dashBoardViewModel);
    }
}