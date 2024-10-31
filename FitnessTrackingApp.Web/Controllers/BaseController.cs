using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessTrackingApp.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string? GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        protected bool IsAuthenticated()
            => this.User.Identity?.IsAuthenticated ?? false;
    }
}
