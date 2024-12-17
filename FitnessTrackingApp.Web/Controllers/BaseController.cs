using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Infrastructure.Extensions;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

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
        
        protected bool IsTrainer()
        {
            return User.IsInRole(TrainerRoleName);
        }

        protected bool IsCustomer()
        {
            return User.IsInRole(CustomerRoleName);
        }

        protected async Task<Guid> GetTrainerId()
        {
            Guid userId = this.GetUserId();
            
            return await this._trainerService
                .GetTrainerPrimaryKeyAsync(userId);
        }
    }
}
