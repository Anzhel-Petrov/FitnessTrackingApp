using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Controllers;

//[Area("Trainer")]
//[Authorize(Roles = "Trainer")]
public class TrainerController : BaseController
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    public async Task<IActionResult> Index()
    {
        var allAvailableTrainers = await _trainerService.GetAvailableTrainersAsync();
        return View(allAvailableTrainers);
    }
}