using FitnessTrackingApp.Common;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Web.ViewModels.Customer;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface IGoalPlanService
{
    Task<OperationResult> CreateGoalPlanAsync(CustomerDetailsInputModel model, Guid userId);
}