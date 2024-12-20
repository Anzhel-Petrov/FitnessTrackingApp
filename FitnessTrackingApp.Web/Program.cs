using FitnessTrackingApp.Data;
using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Services.Data;
using FitnessTrackingApp.Services.Data.Interfaces;
using FitnessTrackingApp.Web.Infrastructure.Extensions;
using FitnessTrackingApp.Web.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FitnessTrackingApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services
                .AddDbContext<FitnessTrackingAppDbContext>(options =>
                    options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                {
                    // Sign In
                    options.SignIn.RequireConfirmedAccount = builder
                        .Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                    ////Password
                    options.Password.RequireDigit = builder
                        .Configuration.GetValue<bool>("Identity:Password:RequireDigit");
                    options.Password.RequireLowercase = builder
                        .Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                    options.Password.RequireUppercase = builder
                        .Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                    options.Password.RequireNonAlphanumeric = builder
                        .Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequiredLength = builder
                        .Configuration.GetValue<int>("Identity:Password:RequiredLength");
                    options.Lockout.AllowedForNewUsers = true;
                })
                .AddEntityFrameworkStores<FitnessTrackingAppDbContext>()
                .AddDefaultTokenProviders();;

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services.AddScoped<IBodyWeightService, BodyWeightService>();
            builder.Services.AddScoped<IMacroService, MacroService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();
            builder.Services.AddScoped<IGoalPlanService, GoalPlanService>();
            builder.Services.AddScoped<IWeeklyPlanService, WeeklyPlanService>();
            builder.Services.AddScoped<IUserService, UserService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            WebApplication app = builder.Build();

            app.SeedRoles();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
                app.AddUsersToRoles();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
