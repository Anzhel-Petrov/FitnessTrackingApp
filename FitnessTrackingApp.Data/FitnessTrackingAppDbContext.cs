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

    public DbSet<BodyWeightGoal> BodyWeightGoals { get; set; } = null!;
    public DbSet<BodyWeightLog> BodyWeightLogs { get; set; } = null!;
    public DbSet<Macro> Macros { get; set; } = null!;
    public DbSet<CardioSession> CardioSessions { get; set; } = null!;
    public DbSet<GoalPlan> GoalPlans { get; set; } = null!;
    public DbSet<WeeklyPlan> WeeklyPlans { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<BodyWeightLog>()
            .HasIndex(l => l.DateLogged)
            .IsUnique();

        builder.Entity<WeeklyPlan>()
            .HasIndex(w => new { w.Week, w.GoalPlanId })
            .IsUnique();
    }
}