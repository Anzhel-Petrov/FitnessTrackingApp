using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using static FitnessTrackingApp.Common.NotificationMessageConstants;
using static FitnessTrackingApp.Common.ErrorMessageConstants;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;
using System.Data;

namespace FitnessTrackingApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UserController(SignInManager<ApplicationUser> signInManager, 
                              UserManager<ApplicationUser> userManager,
                              IUserStore<ApplicationUser> userStore)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._userStore = userStore;
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
            await this._userManager.AddToRoleAsync(user, CustomerRoleName);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginViewModel loginViewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(loginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(loginViewModel);
            }

            SignInResult result = 
                await this._signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] = InvalidLogin;

                return this.View(loginViewModel);
            }

            return this.Redirect(loginViewModel.ReturnUrl ?? "/Home/Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
