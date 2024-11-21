using FitnessTrackingApp.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.Trainer;

namespace FitnessTrackingApp.Services.Data;

public class TrainerService : ITrainerService
{
    private readonly FitnessTrackingAppDbContext _dbContext;

    public TrainerService(FitnessTrackingAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<List<CustomerViewModel>> GetUnassignedCustomersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<CustomerViewModel>> GetAssignedCustomersAsync(Guid trainerId)
    {
        throw new NotImplementedException();
    }

    public Task AssignCustomerAsync(Guid trainerId, Guid customerId)
    {
        throw new NotImplementedException();
    }
}