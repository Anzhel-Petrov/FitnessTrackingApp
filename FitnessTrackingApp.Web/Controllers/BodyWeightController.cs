using FitnessTrackingApp.Data;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
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
        public async Task<IActionResult> AddBodyWeightGoal()
        {
            return View();
        }
    }
}
