using FitnessTrackingApp.Common;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.ViewModels.BodyWeight;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.Web.Controllers
{
    public class BodyWeightController : BaseController
    {
        private readonly IBodyWeightService _bodyWeightService;

        public BodyWeightController(IBodyWeightService bodyWeightService, ITrainerService trainerService)
            : base(trainerService)
        {
            _bodyWeightService = bodyWeightService;
        }


    }
}