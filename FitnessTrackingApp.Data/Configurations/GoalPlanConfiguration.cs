using FitnessTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Data.Configurations;

public class GoalPlanConfiguration : IEntityTypeConfiguration<GoalPlan>
{
    public void Configure(EntityTypeBuilder<GoalPlan> builder)
    {
        builder.HasKey(gp => gp.Id);
        
        builder.HasOne(gp => gp.ApplicationUser)
            .WithMany()
            .HasForeignKey(gp => gp.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(gp => gp.Trainer)
            .WithMany(t => t.GoalPlans)
            .HasForeignKey(gp => gp.TrainerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(gp => new { gp.TrainerId, gp.UserId })
            .HasFilter(OnlyOneActiveGoalPlan)
            .IsUnique();
        
        builder.Property(gp => gp.IsActive).HasDefaultValue(false);
    }
}