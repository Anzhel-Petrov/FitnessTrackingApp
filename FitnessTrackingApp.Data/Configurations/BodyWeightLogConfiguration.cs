using FitnessTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTrackingApp.Data.Configurations;

public class BodyWeightLogConfiguration : IEntityTypeConfiguration<BodyWeightLog>
{
    public void Configure(EntityTypeBuilder<BodyWeightLog> builder)
    {
        builder.HasIndex(l => new { l.DateLogged, l.WeeklyPlanId})
            .IsUnique();
        
        builder.HasOne(b => b.WeeklyPlan)
            .WithMany(w => w.BodyWeightLogs)
            .HasForeignKey(b => b.WeeklyPlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}