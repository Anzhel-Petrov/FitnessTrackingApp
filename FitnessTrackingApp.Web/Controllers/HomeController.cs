using System.Diagnostics;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FitnessTrackingApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            if (await this.IsUserTrainerAsync())
            {
                return this.RedirectToAction("Index", "Dashboard", new { Area = "Trainer" });
            }
            
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
