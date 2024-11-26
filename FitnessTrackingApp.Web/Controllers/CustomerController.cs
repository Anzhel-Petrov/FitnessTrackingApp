using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.NotificationMessageConstants;
using static FitnessTrackingApp.Common.ErrorMessageConstants;
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SelectTrainer(Guid trainerId)
    {
        var result = await _trainerService.AssignTrainerToCustomerAsync(this.GetUserId(), trainerId);

        if (!result)
        {
            TempData[ErrorMessage] = ErrorAssigningTrainer;
            return RedirectToAction(nameof(AvailableTrainers));
        }

        TempData[SuccessMessage] = TrainerSelectedSuccess;
        return RedirectToAction(nameof(AvailableTrainers));
    }
}