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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}