using System.Security.Claims;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessTrackingApp.Web.Infrastructure.Attributes;

public class MustBeTrainerAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var trainerService = context.HttpContext.RequestServices.GetService<ITrainerService>();
        if (trainerService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return;
        }

        var userId = context.HttpContext.User.GetId();
        if (string.IsNullOrEmpty(userId) || !await trainerService.TrainerExistsByUserIdAsync(userId))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }

        await next();
    }
}