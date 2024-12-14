using System.Diagnostics;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FitnessTrackingApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ITrainerService trainerService) : base(trainerService)
        {
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(TrainerRoleName))
            {
                return this.RedirectToAction("Index", "Dashboard", new { Area = "Trainer" });
            }

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            if (statusCode == 404 || statusCode == 400)
            {
                return this.View("Error404");
            }
            if (statusCode == 401)
            {
                return this.View("Error401");
            }
            return View();
        }


    }
}
