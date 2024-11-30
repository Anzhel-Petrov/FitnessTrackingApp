using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Controllers;

public class TrainerController : BaseController
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
        : base(trainerService)
    {
        _trainerService = trainerService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}