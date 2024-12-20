﻿using FitnessTrackingApp.Web.ViewModels.Customer;
using FitnessTrackingApp.Web.ViewModels.Trainer;

namespace FitnessTrackingApp.Services.Data.Interfaces;

public interface ITrainerService
{
    Task<bool> TrainerExistsByUserIdAsync(string userId);
    Task<bool> TrainerExistsByIdAsync(string userId);
    Task<IEnumerable<TrainerViewModel>> GetAvailableTrainersAsync(Guid userId);
    Task<Guid> GetTrainerPrimaryKeyAsync(Guid trainerUserId);
}