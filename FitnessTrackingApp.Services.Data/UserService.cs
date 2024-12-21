using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Services.Data;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
    {
        IEnumerable<ApplicationUser> allUsers = await _userManager.Users.ToArrayAsync();

        ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

        foreach (ApplicationUser user in allUsers)
        {
            IEnumerable<string> roles = await _userManager.GetRolesAsync(user);

            allUsersViewModel.Add(new AllUsersViewModel()
            {
                Id = user.Id,
                Email = user.Email!,
                Roles = roles,
            });
        }

        return allUsersViewModel;
    }

    public async Task<OperationResult> LockUserAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            return new OperationResult(false, "No such user is found.");
        }

        user.LockoutEnd = DateTime.UtcNow.AddDays(1);

        await _userManager.UpdateAsync(user);

        return new OperationResult(true, "User locked for 1 day");
    }
}