using FitnessTrackingApp.Web.ViewModels.Trainer;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface ITrainerService
{
    Task<List<CustomerViewModel>> GetUnassignedCustomersAsync();
    Task<List<CustomerViewModel>> GetAssignedCustomersAsync(Guid trainerId);
    Task AssignCustomerAsync(Guid trainerId, Guid customerId);
}