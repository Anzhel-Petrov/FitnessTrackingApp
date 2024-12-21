using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Controllers;
using FitnessTrackingApp.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserManagementController : BaseController
    {
        private readonly IUserService _userService;
        public UserManagementController(ITrainerService trainerService, IUserService userService) : base(trainerService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<AllUsersViewModel> allUsers = await _userService.GetAllUsersAsync();

                return View(allUsers);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while fetching the users. Please try again later.";

                return View(Enumerable.Empty<AllUsersViewModel>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> LockUser(Guid userId)
        {
            var result = await _userService.LockUserAsync(userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
