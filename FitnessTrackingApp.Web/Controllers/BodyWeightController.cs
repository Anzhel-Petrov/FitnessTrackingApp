using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Web.Controllers
{
    public class BodyWeightController : BaseController
    {
        private readonly FitnessTrackingAppDbContext _dbContext;
        public BodyWeightController(FitnessTrackingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Details()
        {
            var bodyWeightGoal = await _dbContext.BodyWeightGoals
                .FirstOrDefaultAsync(g => g.IsActive && g.UserId == this.GetUserId());

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

                var activeGoal = await _dbContext.BodyWeightGoals
                .FirstOrDefaultAsync(g => g.IsActive && g.UserId == userId);;

                if (activeGoal != null)
                {
                    activeGoal.IsActive = false;  // Deactivate the current goal
                    _dbContext.BodyWeightGoals.Update(activeGoal);
                }

                BodyWeightGoal bodyWeightGoal = new BodyWeightGoal()
                {
                    UserId = userId,
                    GoalWeight = bodyWeightGoalCreateViewModel.GoalWeight,
                    IsActive = true,
                    DateAdded = DateTime.Today
                };

                _dbContext.BodyWeightGoals.Add(bodyWeightGoal);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }

            return View(nameof(Details), new BodyWeightDetailsViewModel{ GoalWeightViewModel = bodyWeightGoalCreateViewModel });
        }
    }
}
