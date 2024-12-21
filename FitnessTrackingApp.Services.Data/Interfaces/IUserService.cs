using FitnessTrackingApp.Common;
using FitnessTrackingApp.Web.ViewModels.User;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IUserService
{
    Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
    Task<OperationResult> LockUserAsync(Guid userId);
}