﻿using FitnessTrackingApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Infrastructure.Extensions;

public static class WebApplicationBuilderExtensions
{
    private static readonly string[] RoleNames = [TrainerRoleName, CustomerRoleName, AdminRoleName];

    public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
    {
        using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

        //Get DI container service provider
        IServiceProvider serviceProvider = scopedServices.ServiceProvider;
        UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        

        Task.Run(async () =>
            {
                bool allRolesExist = true;
                foreach (var roleName in RoleNames)
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
                    foreach (var roleName in RoleNames)
                    {
                        if (!await roleManager.RoleExistsAsync(roleName))
                        {
                            IdentityRole<Guid> newRole = new IdentityRole<Guid>(roleName);
                            await roleManager.CreateAsync(newRole);
                        }
                    }
                }
            })
            .GetAwaiter()
            .GetResult();
        // To do chaining
        return app;
    }

    public static IApplicationBuilder AddUsersToRoles(this IApplicationBuilder app)
    {
        using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

        //Get DI container service provider
        IServiceProvider serviceProvider = scopedServices.ServiceProvider;
        UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(TrainerRoleName))
                {
                    foreach (var trainerId in TrainerIds)
                    {
                        ApplicationUser? userToFind = await userManager.FindByIdAsync(trainerId);

                        if (userToFind != null)
                        {
                            if (!await userManager.IsInRoleAsync(userToFind, TrainerRoleName))
                            {
                                await userManager.AddToRoleAsync(userToFind, TrainerRoleName);
                            }
                        }
                    }
                }

                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    ApplicationUser? userToFind = await userManager.FindByIdAsync(AdminId);
                    if (userToFind != null)
                        await userManager.AddToRoleAsync(userToFind, AdminRoleName);
                }

                if (await roleManager.RoleExistsAsync(CustomerRoleName))
                {
                    ApplicationUser? userToFind = await userManager.FindByIdAsync(CustomerId);
                    if (userToFind != null)
                        await userManager.AddToRoleAsync(userToFind, CustomerRoleName);
                }

            })
            .GetAwaiter()
            .GetResult();

        return app;
    }
}