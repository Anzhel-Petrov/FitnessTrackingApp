using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Infrastructure.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
    {
        using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

        //Get DI container service provider
        IServiceProvider serviceProvider = scopedServices.ServiceProvider;
        UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        string[] roleNames = [TrainerRoleName, CustomerRoleName , AdminRoleName];

        Task.Run(async () =>
            {
                var allRolesExist = true;
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        allRolesExist = false;
                        break;
                    }
                }

                if (allRolesExist)
                    return;
                {
                    foreach (var roleName in roleNames)
                    {
                        if (!await roleManager.RoleExistsAsync(roleName))
                        {
                            IdentityRole<Guid> newRole = new IdentityRole<Guid>(roleName);
                            await roleManager.CreateAsync(newRole);
                        }
                    }
                }

                //ApplicationUser userToFind = await userManager.FindByIdAsync(userId);
                //await userManager.AddToRoleAsync(userToFind, AdminRoleName);

            })
            .GetAwaiter()
            .GetResult();
        // To do chaining
        return app;
    }
}