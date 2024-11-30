using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Controllers;

public class MacroController : BaseController
{
    private readonly IMacroService _macroService;
    private readonly IBodyWeightService _bodyWeightService;

    public MacroController(IMacroService macroService, IBodyWeightService bodyWeightService, ITrainerService trainerService)
        : base(trainerService)
    {
        _macroService = macroService;
        _bodyWeightService = bodyWeightService;
    }
    public async Task<IActionResult> Index()
    {
        var lastBodyWeight = await _bodyWeightService.GetLastBodyWeightLogAsync(this.GetUserId());
        
        return View();
    }
}