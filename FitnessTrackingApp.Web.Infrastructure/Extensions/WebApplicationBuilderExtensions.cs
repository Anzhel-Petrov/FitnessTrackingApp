using FitnessTrackingApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static FitnessTrackingApp.Common.GeneralApplicationConstants;

namespace FitnessTrackingApp.Web.Infrastructure.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static IApplicationBuilder SeedUserRole(this IApplicationBuilder app, string userId)
    {
        using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

        //Get DI container service provider
        IServiceProvider serviceProvider = scopedServices.ServiceProvider;
        UserManager<ApplicationUser> userManagaer = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }
                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
                await roleManager.CreateAsync(role);

                ApplicationUser userToFind = await userManagaer.FindByIdAsync(userId);
                await userManagaer.AddToRoleAsync(userToFind, AdminRoleName);

            })
            .GetAwaiter()
            .GetResult();
        // To do chaining
        return app;
    }
    
    public static IApplicationBuilder SeedTrainer(this IApplicationBuilder app, string userId)
    {
        using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

        //Get DI container service provider
        IServiceProvider serviceProvider = scopedServices.ServiceProvider;
        UserManager<ApplicationUser> userManagaer = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }
                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
                await roleManager.CreateAsync(role);

                ApplicationUser userToFind = await userManagaer.FindByIdAsync(userId);
                await userManagaer.AddToRoleAsync(userToFind, AdminRoleName);

            })
            .GetAwaiter()
            .GetResult();
        // To do chaining
        return app;
    }
}