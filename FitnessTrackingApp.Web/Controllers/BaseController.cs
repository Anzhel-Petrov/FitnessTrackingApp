﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Infrastructure.Extensions;

namespace FitnessTrackingApp.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private readonly ITrainerService _trainerService;

        public BaseController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        
        protected Guid GetUserId()
            => Guid.TryParse(this.User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : Guid.Empty;

        protected bool IsAuthenticated()
            => this.User.Identity?.IsAuthenticated ?? false;
        
        protected async Task<bool> IsUserTrainerAsync()
        {
            string? userId = this.User.GetUserId();
            
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }
            
            bool isTrainer = await this._trainerService
                .TrainerExistsByUserIdAsync(userId);
            
            return isTrainer;
        }
        
        protected async Task<Guid> GetTrainerId()
        {
            Guid userId = this.GetUserId();
            
            return await this._trainerService
                .GetTrainerPrimaryKeyAsync(userId);
        }
    }
}
