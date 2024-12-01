using FitnessTrackingApp.Data.Models;
using FitnessTrackingApp.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessTrackingApp.Common.ApplicationConstants;

namespace FitnessTrackingApp.Data.Configurations;

public class GoalPlanConfiguration : IEntityTypeConfiguration<GoalPlan>
{
    public void Configure(EntityTypeBuilder<GoalPlan> builder)
    {
        builder.HasKey(gp => gp.Id);
        
        builder.HasOne(gp => gp.CustomerDetails)
            .WithOne(cd => cd.GoalPlan)
            .IsRequired();
        
        builder.HasOne(gp => gp.ApplicationUser)
            .WithMany()
            .HasForeignKey(gp => gp.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(gp => gp.Trainer)
            .WithMany(t => t.GoalPlans)
            .HasForeignKey(gp => gp.TrainerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Customer can have only one Active GoalPlan
        builder.HasIndex(gp => gp.UserId)
            .HasFilter(OnlyOneActiveGoalPlan)
            .IsUnique();
        
        // Customer can have only one Pending GoalPlan
        builder.HasIndex(gp => gp.UserId)
            .HasFilter(OnlyOnePendingGoalPlan)
            .IsUnique();
        
        // Customer can have only one Pending GoalPlan (Pending request) with Trainer (a bit redundant)
        // builder.HasIndex(gp => new { gp.TrainerId, gp.UserId })
        //     .HasFilter(OnlyOnePendingGoalPlan)
        //     .IsUnique();
        
        // Customer can have only one Active GoalPlan with Trainer (a bit redundant)
        // builder.HasIndex(gp => new { gp.TrainerId, gp.UserId })
        //     .HasFilter(OnlyOneActiveGoalPlan)
        //     .IsUnique();

        builder.Property(gp => gp.GoalPlanStatus).HasDefaultValue(GoalPlanStatus.Pending);
    }
}