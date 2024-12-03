using FitnessTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class BodyWeightLogConfiguration : IEntityTypeConfiguration<BodyWeightLog>
{
    public void Configure(EntityTypeBuilder<BodyWeightLog> builder)
    {
        builder.HasIndex(l => new { l.DateLogged, l.GoalPlanId})
            .IsUnique();
        
        builder.HasOne(bwl => bwl.GoalPlan)
            .WithMany(gp => gp.BodyWeightLogs)
            .HasForeignKey(bwl => bwl.GoalPlanId);
    }
}