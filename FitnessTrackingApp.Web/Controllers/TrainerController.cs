using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Controllers;

//[Area("Trainer")]
[Authorize(Roles = "Trainer")]
public class TrainerController : BaseController
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }
    
    public async Task<IActionResult> UnassignedCustomers()
    {
        var customers = await _trainerService.GetUnassignedCustomersAsync();
        return View(customers);
    }
    
    public async Task<IActionResult> AssignedCustomers()
    {
        var trainerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var customers = await _trainerService.GetAssignedCustomersAsync(trainerId);
        return View(customers);
    }
    
    [HttpPost]
    public async Task<IActionResult> AssignCustomer(Guid customerId)
    {
        var trainerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _trainerService.AssignCustomerAsync(trainerId, customerId);
        return RedirectToAction(nameof(UnassignedCustomers));
    }
}