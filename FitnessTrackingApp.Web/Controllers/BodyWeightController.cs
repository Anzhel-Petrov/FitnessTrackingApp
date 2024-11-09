using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Web.Controllers
{
    public class BodyWeightController : BaseController
    {
        private readonly IBodyWeightService _bodyWeightService;
        public BodyWeightController(IBodyWeightService bodyWeightService)
        {
            _bodyWeightService = bodyWeightService;
        }
        public async Task<IActionResult> Details()
        {
            var bodyWeightGoal = await _bodyWeightService.GetBodyWeightGoalAsync(this.GetUserId());

            BodyWeightDetailsViewModel bodyWeightDetailsViewModel = new BodyWeightDetailsViewModel()
            {
                BodyWeightGoal = bodyWeightGoal
            };

            return View(bodyWeightDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodyWeightGoal(BodyWeightGoalCreateViewModel bodyWeightGoalCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                Guid userId = this.GetUserId() ?? Guid.Empty;

                //var existingWeightGoal = await _bodyWeightService.GetBodyWeightGoalAsync(userId);

                await _bodyWeightService.AddBodyWeightGoal(userId, bodyWeightGoalCreateViewModel.GoalWeight);

                return RedirectToAction(nameof(Details));
            }

            return View(nameof(Details), new BodyWeightDetailsViewModel{ GoalWeightViewModel = bodyWeightGoalCreateViewModel });
        }

        [HttpGet]
        public async Task<IActionResult> AddBodyWeightLog()
        {
            return View(nameof(Details));
        }
    }
}
