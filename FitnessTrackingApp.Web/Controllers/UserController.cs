using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UserController(SignInManager<ApplicationUser> signInManager, 
                              UserManager<ApplicationUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(registerViewModel);
            }

            ApplicationUser user = new ApplicationUser();

            await this._userManager.SetEmailAsync(user, registerViewModel.Email);
            await this._userManager.SetUserNameAsync(user, registerViewModel.Email);

            IdentityResult result = await this._userManager.CreateAsync(user, registerViewModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.View(registerViewModel);
            }

            await this._signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
    }
}
