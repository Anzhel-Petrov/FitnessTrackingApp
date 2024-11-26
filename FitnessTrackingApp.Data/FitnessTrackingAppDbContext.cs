using System.Reflection;
using FitnessTrackingApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.Data;

public class FitnessTrackingAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public FitnessTrackingAppDbContext()
    {
        
    }

    public FitnessTrackingAppDbContext(DbContextOptions options)
        : base(options)
    {
        
    }

    public DbSet<ApplicationUser> Users { get; set; } = null!;
    public DbSet<BodyWeightGoal> BodyWeightGoals { get; set; } = null!;
    public DbSet<BodyWeightLog> BodyWeightLogs { get; set; } = null!;
    public DbSet<Macro> Macros { get; set; } = null!;
    public DbSet<CardioSession> CardioSessions { get; set; } = null!;
    public DbSet<GoalPlan> GoalPlans { get; set; } = null!;
    public DbSet<WeeklyPlan> WeeklyPlans { get; set; } = null!;
    public DbSet<Trainer> Trainers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var configurationAssembly = Assembly.GetAssembly(typeof(FitnessTrackingAppDbContext)) ??
                                    Assembly.GetExecutingAssembly();

        builder.ApplyConfigurationsFromAssembly(configurationAssembly);

        base.OnModelCreating(builder);
    }
}