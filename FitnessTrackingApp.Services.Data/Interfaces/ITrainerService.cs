using FitnessTrackingApp.Web.ViewModels.Trainer;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface ITrainerService
{
    Task<IEnumerable<TrainerViewModel>> GetAvailableTrainersAsync();
}