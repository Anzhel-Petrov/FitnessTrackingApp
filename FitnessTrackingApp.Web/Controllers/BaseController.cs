using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessTrackingApp.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected Guid GetUserId()
            => Guid.TryParse(this.User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : Guid.Empty;

        protected bool IsAuthenticated()
            => this.User.Identity?.IsAuthenticated ?? false;
    }
}
