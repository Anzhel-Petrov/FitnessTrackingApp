using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;
using static FitnessTrackingApp.Common.SuccessMessagesConstants;

namespace FitnessTrackingApp.Web.Controllers;

public class CustomerController : BaseController
{
    private readonly ITrainerService _trainerService;

    public CustomerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    [HttpGet]
    public async Task<IActionResult> AvailableTrainers()
    {
        var trainers = await _trainerService.GetAvailableTrainersAsync();
        return View(trainers);
    }

    [HttpPost]
    public async Task<IActionResult> SelectTrainer(Guid trainerId)
    {
        var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        //await _trainerService.AssignTrainerToCustomerAsync(Guid.Parse(customerId), trainerId);

        TempData[SuccessMessage] = TrainerSelectedSuccess; 
        return RedirectToAction(nameof(AvailableTrainers));
    }
}