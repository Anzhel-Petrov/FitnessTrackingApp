using System.Security.Claims;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Infrastructure.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.IsInRole(AdminRoleName);
    }

    public static string? GetUserName(this ClaimsPrincipal? user)
    {
        return user?.FindFirstValue(ClaimTypes.Name) ?? null;
    }
    
    public static string? GetUserId(this ClaimsPrincipal? user)
    {
        return user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
    }
}