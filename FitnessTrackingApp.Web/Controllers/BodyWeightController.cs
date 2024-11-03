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
        public IActionResult Details()
        {
            var bodyWeightGoal = _dbContext.BodyWeightGoals.FirstOrDefault();

            BodyWeightDetailsViewModel bodyWeightDetailsViewModel = new BodyWeightDetailsViewModel()
            {
                BodyWeightGoal = bodyWeightGoal
            };

            return View(bodyWeightDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBodyWeightGoal(decimal weight)
        {
            if (ModelState.IsValid)
            {
                Guid userId = this.GetUserId() ?? Guid.Empty;

                var activeGoal = await _dbContext.BodyWeightGoals
                    .Where(g => g.UserId == userId && g.IsActive)
                    .FirstOrDefaultAsync();

                if (activeGoal != null)
                {
                    activeGoal.IsActive = false;  // Deactivate the current goal
                    _dbContext.BodyWeightGoals.Update(activeGoal);
                }

                BodyWeightGoal bodyWeightGoal = new BodyWeightGoal()
                {
                    GoalWeight = weight,
                    UserId = userId,
                    IsActive = true,
                    DateAdded = DateTime.Today
                };

                _dbContext.BodyWeightGoals.Add(bodyWeightGoal);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }

            return View();
        }
    }
}
